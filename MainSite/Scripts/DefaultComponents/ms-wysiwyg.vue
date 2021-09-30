<template>
    <div class='texteditor'>
        <div class='banner'>
            <div class="wysiwyg_loader">
                <ms-loader-files
                    @changeFileList="changeFileList"
                    :fileList="fileList"
                />
            </div>
            <div class="wysiwyg_list">

                <ms-select 
                  :selected="formatBlockSelected.name"
                  :options="formatBlockList"
                  @select="changeSelectFormatBlock" 
                  :isCursorEdit="true"
                />

                <div class="wysiwyg_list__btn">  
                  <i title="Жирный" class="material-icons intLink" @click="formatDoc('bold');" onmousedown="return false" onselectstart="return false">format_bold</i>
                  <i title="Курсивный" class="material-icons intLink" @click="formatDoc('italic');" onmousedown="return false" onselectstart="return false">format_italic</i>
                  <i title="Подчеркнутый" class="material-icons intLink" @click="formatDoc('underline');" onmousedown="return false" onselectstart="return false">format_underline</i>
                </div>
                <div class="wysiwyg_list__btn">
                  <i title="Выравнивание слева" class="material-icons intLink" @click="formatDoc('justifyleft');" onmousedown="return false" onselectstart="return false">format_align_left</i>
                  <i title="Выравнивание по центру" class="material-icons intLink" @click="formatDoc('justifycenter');" onmousedown="return false" onselectstart="return false">format_align_center</i>
                  <i title="Выравнивание справа" class="material-icons intLink" @click="formatDoc('justifyright');" onmousedown="return false" onselectstart="return false">format_align_right</i>
                </div>
                <div class="wysiwyg_list__btn">  
                  <i title="Нумерованный список" class="material-icons intLink" @click="formatDoc('insertorderedlist');" onmousedown="return false" onselectstart="return false">format_list_numbered</i>
                  <i title="Маркированный список" class="material-icons intLink" @click="formatDoc('insertunorderedlist');" onmousedown="return false" onselectstart="return false">format_list_bulleted</i>
                  <i title="Блок с цитатой" class="material-icons intLink" @click="formatDoc('formatblock','blockquote');" onmousedown="return false" onselectstart="return false">format_quote</i>
                  <i title="Уменьшить на единицу отступ блока форматирования" class="material-icons intLink" @click="formatDoc('outdent');" onmousedown="return false" onselectstart="return false">format_indent_decrease</i>
                  <i title="Увеличить на единицу отступ блока форматирования" class="material-icons intLink" @click="formatDoc('indent');" onmousedown="return false" onselectstart="return false">format_indent_increase</i>
                </div>
                <div class="wysiwyg_list__btn">
                  <i title="Ссылка" class="material-icons intLink" @click="setLink" onmousedown="return false" onselectstart="return false">link</i>
                  <label class="file_loader_label">
                    <input ref="file" type="file" id="inputFileToLoad" />
                    <i title="Добавить картинку" class="material-icons intLink" onmousedown="return false" onselectstart="return false">image</i>
                  </label>
                </div>
            </div>
        </div>
        <div class='holder'>
            <div v-on:input="changeTextEditor" contentEditable="true" name='wysiwyg' class="wysiwyg" :id='GUUID' v-html="parentTextEditor">
            </div>
        </div>
    </div>
</template>

<script>
    import msPopup from "./ms-popup.vue"
    import msSelect from './ms-select.vue'
    import msLoaderFiles from './ms-loader-files.vue'
    import ResizeService from '../Services/ResizeService.js'
    export default {
        name: "ms-wysiwyg",
        props: {
            parentTextEditor: {
                type: String,
                default: () => { return '' }
            },
            fileList: {
                type: Array,
                default: () => { return [] }
            }
        },
        data() {
            return {
                editor: {},
                textMessage: '',
                isInfoPopupVisible: false,
                actionLoad: '',
                isImage: false,
                formatBlockList: [{ name: "Обычный текст", value: "p" }, { name: "Название темы", value: "h1" },
                 { name: "Название раздела", value: "h2" }, { name: "Название подраздела", value: "h3" }
                ],
                formatBlockSelected: { name: "Обычный текст", value: "p" },
                fileListDropDownSelected: { name: "Список файлов &#129131;", value: "" },
                currentImage: {}
            }
        },
        components: {
            msPopup,
            msSelect,
            msLoaderFiles
        },
        computed: {
            GUUID() {
                return "wysiwyg_" + new Date();
            },
            formListDropDown() {
                return this.fileList.map(function(item, index){
                    return { name: item.FormFile.name, value:item.Id}
                })
            }
        },
        methods: {   
            changeTextEditor() {
                this.$emit('input', this.editor.innerHTML);
            },
            changeResizeEditor(editor) {
                this.$emit('input', editor);
            },
            loadIframe() { 
                this.editor = document.getElementById(this.GUUID);
                if (this.parentTextEditor !== '') this.$emit('input', this.parentTextEditor);
                let vm = this;

                this.editor.addEventListener('click', function (e) {
                    e.preventDefault();
                    if (e.target.tagName == 'IMG') {
                        if(e.target.getAttribute('_moz_resizing')) {
                            document.addEventListener('mouseup', () => {
                                if(vm.editor.clientWidth < e.target.clientWidth) {
                                    e.target.setAttribute('width', vm.editor.clientWidth - 20);
                                    vm.$emit('input', vm.editor.innerHTML);
                                }
                            });
                        }
                        else {
                            document.execCommand('enableObjectResizing', false, 'false');
                            let t = new ResizeService(e.target, vm);
                        }
                    }
                    return false;
                }, false);
            },
            formatDoc(sCmd, sValue) {
                document.execCommand(sCmd, false, sValue);
                this.editor.focus();
            },
            changeSelectFormatBlock(selectDropDownElement) {                       
                this.formatBlockSelected = selectDropDownElement;     
                document.execCommand('formatBlock', false, selectDropDownElement.value)
            },
            addFileForBody(file) {
                if (file) {
                    let vm = this;
                    let reader = new FileReader(file);
                    
                    reader.readAsDataURL(file);
                    if (file.type.match("image.*")) {
                        reader.onload = async function (e) {   
                            e.preventDefault();               
     
                            let img = await new Promise((resolve, reject) => {
                                let elementImg = document.createElement('img')
                                elementImg.src = e.target.result;

                                elementImg.onload =  function() {
                                    let imgWidth = elementImg.width;
                                    let imgHeight = elementImg.height;
                                    let scale = imgWidth / imgHeight;
                                    let tempHeight = vm.editor.offsetHeight * 3 / 5 - 30
                                    let tempWidth = tempHeight * scale

                                    if(tempWidth >= vm.editor.offsetWidth) {
                                        tempWidth = vm.editor.offsetWidth * 3 / 5 - 30
                                    }
                            
                                    elementImg.width = tempWidth;                        
                                    elementImg.height = tempHeight;

                                    return resolve(elementImg);
                                };
                            });

                            let focus = vm.setFocus();
                            if(focus != null && focus.getAttribute('name') == 'wysiwyg') {
                              vm.formatDoc("insertHTML", img.outerHTML);
                            }
                            else {
                              vm.editor.appendChild(img);
                              vm.editor.focus();
                            }
                        }                        
                    }   
                }
                else {
                }
            },
            setFocus() {
                let focused = document.activeElement;
                if (!focused || focused == document.body)
                    focused = null;
                else if (document.querySelector)
                    focused = document.querySelector(":focus");
                
                return focused
            },
            changeFileList(changeFileListData) {
                this.$emit('changeFileList', changeFileListData);
            },
            changeFormatBlockSelected() {
                this.formatDoc('formatblock', this.formatBlockSelected);
            },
            setLink() {
                let sLnk = prompt('Напишите ссылку', '');
                if (sLnk && sLnk != '') {
                    this.formatDoc('createlink', sLnk);
                }
            },
            listenerImageLoader() {
                let imageLoader = document.querySelector('.file_loader_label > input[type="file"]')
                let vm = this
                imageLoader.addEventListener('change', function() {
                    vm.addFileForBody(this.files[0])
                })
            }
        },
        beforeDestroy() {
            this.editor = {};
            this.formatBlockSelected =  "Обычный текст";
            this.changeTextEditor();
            this.$emit('changeFileList', []);
        },
        mounted() {
            this.loadIframe()
            this.listenerImageLoader()
        }
    };
</script>

<style lang="scss">
    .decorate_block {
        -moz-user-select: none; /* Firefox */
        * {
            -webkit-touch-callout: none; /* iOS Safari */
            -khtml-user-select: none; /* Konqueror HTML */
            -moz-user-select: none; /* Firefox */
            -ms-user-select: none; /* Internet Explorer/Edge */
        }
    }
    .file_loader_label {
        input[type="file"] {
            display: none;
        }
    }

    .wysiwyg_loader {
        margin-top: 10px;
    }

    .wysiwyg_list {
        display: flex;
        align-items: center;
        flex-wrap: wrap;
        & .ms-select {
            width: 170px;
            font-size: 14px;
            & .title {
                border-radius: 8px;
                line-height: 1;
            }
        }

        &__btn {
            display: flex;
            border-right: 1px solid black;
            & > i, label {
                padding-right: 10px;
                padding-left: 10px;  
            }

            &:last-child {
                border-right:none;                   
            }
        }
    }

    .wysiwyg {
        padding: 15px;
        border: 1px solid #9e9e9e;
        border-radius: 8px;
        background-color: #eeeeee;
        color: #9e9e9e;
        height:400px;
        margin-bottom: 15px;
        overflow-y:scroll;
        overflow-x: hidden;
        &:focus {
           background-color: white;
        }

        p {
            margin: 0;
        }
    }

    .wysiwyg {
        & ul, ol
        {
            padding-inline-start: 40px;
        }

        & ul {
            list-style: disc !important;
            & > li
            {
                list-style: disc !important;
                text-align:left;
            }
        }
    }

    .intLink {
        cursor: pointer;
        color: black;
    }

    img.intLink {
        border: 0;
    }


    #textBox {
        width: 540px;
        height: 200px;
        border: 1px #000000 solid;
        padding: 12px;
        overflow: scroll;
    }

    #textBox #sourceText {
        padding: 0;
        margin: 0;
        min-width: 498px;
        min-height: 200px;
    }

    #editMode label {
        cursor: pointer;
    }
</style>
