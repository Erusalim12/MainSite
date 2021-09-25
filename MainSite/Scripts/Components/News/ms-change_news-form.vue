<template>
  <form ref="formCreateNews" v-on:submit.prevent="submit" action="/Home/Create/" enctype="multipart/form-data" method="post">
    <input name="Id" type="hidden" v-model="model.id" />
    <input name="CategoryId" type="hidden" :value="categoryId" />
    <input name="IsAdvancedEditor" type="hidden" :value="isAdvancedEditor" />

    <div class="s12 m12">
      <div class="bold">Введите заголовок объявления:</div>
      <div class="error" style="font-size:14px;" v-if="isErrorHeader">Вы должны вести заголовок сообщения</div>
      <input ref="formTitle" name="Header" id="TextHeader" class="inputTextMainSite" type="text" v-model="model.header"/>
    </div>
    <ms-wysiwyg 
      v-model="textEditor"
      :fileList="fileList"
      :parentTextEditor="Description"
      @changeFileList="changeFileList" />
    <input type="hidden" v-model="textEditor" name="Description" id="TextDescription" />
    <input style="display: flex; margin-left: auto;" type="submit" class="btn btn-defaultMainSite" :value="textSubmit" />
  </form>
</template>

<script>
  import MsWysiwyg from '../../DefaultComponents/ms-wysiwyg.vue';
  import { mapActions } from 'vuex';
  
  export default {
    name: 'ms-change_news-form',
    props: {
      isAdvancedEditor: {
        type: Boolean,
        default: () => { return false }
      },
      categoryId: {
        type: String,
        default: () => { return '' }
      },
      textSubmit: {
        type: String,
        default: () => { return 'Опубликовать' }
      },
      editModel: {
        type: Object,
        default: () => { return null }
      },
      editFiles: {
        type: Array,
        default: () => { return [] }
      }
    },
    data: () => {
      return {
        model: {
          header: ''
        },
        textEditor: '',
        fileList: [],
        isErrorHeader: false
      }
    },
    computed: {
      Description() {
        return this.editModel != null ? this.editModel.description : '';
      }
    },
    components: {
      MsWysiwyg
    },
    methods: {
      ...mapActions('news', [
        'GET_FILE'
      ]),
      GetEditFileNameInput(index, key) {
        return "Files[" + index + "]." + key;
      },
      changeFileList(changeFileListData) {
        this.fileList = changeFileListData;                         
      },
      GenerateUUID() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
          var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
          return v.toString(16);
        }).toUpperCase();
      },
      submit(e) {
        e.preventDefault();

        if(this.$refs.formTitle.value.trim() === '') {
          this.isErrorHeader = true;
          return;
        }

        let formData = new FormData(this.$refs.formCreateNews);

        if (this.isAdvancedEditor) {
          let i = 0;
          for (var i = 0; i < this.fileList.length; i++) {
            if(typeof this.fileList[i].dataBaseName == 'undefined') {
              formData.append(`Files[${this.GenerateUUID()}]`, this.fileList[i]);  
            }
            else {
              let dataBaseName = typeof this.fileList[i].dataBaseName != 'undefined' ? this.fileList[i].dataBaseName : this.GenerateUUID();
              let file = new File([], this.fileList[i].name + this.fileList[i].extension, { type: this.fileList[i].mimeType, name: dataBaseName})
              if(this.fileList[i].dataBaseName.includes('Files')) {
                formData.append(dataBaseName, file);  
              }
              else {
                formData.append(`Files[${this.GenerateUUID()}]`, file);  
              }
            }                
          }
        }

        let result = {
          params: formData,
          action: e.target.action
        };

        this.$emit('changeNew', result);
      }
    },
    created() {
        if (this.editModel != null) this.model = {...this.editModel};
        if(this.editFiles.length) this.fileList = this.editFiles.map((item, index) => item)
    }
  }
</script>

<style lang="scss" scoped>

</style>