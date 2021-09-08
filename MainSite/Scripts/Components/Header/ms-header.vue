<template>
    <header class="navbar-fixed">
        <nav class="nav-header">
            <div class="container">
                <div class="nav-wrapper">
                    <div class="valign-wrapper">
                        <a style="cursor: pointer;" @click="routerPushMainView" class="valign-wrapper">
                            <img :src="GetApplicationIcon" width="50" height="50" /> 
                            <span 
                              class="bold" 
                              style="padding-left:10px;line-height: 15px;margin-right: 13px;font-size:12px;"
                              v-html="GetApplicationName"
                            ></span>
                        </a>
                        <a id="openMenu" data-target="mobile-demo" class="sidenav-trigger" style="float: right;cursor:pointer;"><i class="material-icons">menu</i></a>
                        <ul class="hide-on-med-and-down col m12 s12 l9 headerMenu" style="padding:0;">
                            <li class="headerMenu-search">
                                    <span style="margin-right:5px;" class="bold">Поиск:</span>
                                    <input style="margin-right:5px;" v-model="searchText" class="inputTextMainSite inputSearch" type="text" />
                                    <button style="margin-right:5px;" class="btn btn-default" @click="searchNews">Найти</button>
                            </li>
                            <li>
                                <div class="headerMenu-user">
                                    <a data-target='dropdown1' class="dropdown-trigger valign-wrapper" style="padding: 0px;">
                                        <span class="headerMenu-user__info">{{currentUser.Name}}</span>
                                        <img src="/images/layout_icons/userLogout.svg" alt="" />
                                        <!--<i class="material-icons">keyboard_arrow_down</i>-->
                                    </a>
                                    <ul id='dropdown1' class='dropdown-content headerMenu-user__settings'>
                                        <li><a href="#!"><i class="material-icons">home</i>Личный кабинет</a></li>
                                        <li><a href="#!"><i class="material-icons">cloud</i>Управление сервисами</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="progress" id="progressLoad" style="background-color:transparent; margin:0px;" v-bind:style="isShow[isActive]">
                <div class="indeterminate" style="background-color:#64b5f6;"></div>
            </div>
        </nav>
    </header>
</template>

<script>
    import { mapState, mapActions, mapMutations } from 'vuex';

    export default {
        name: 'ms-header',
        data() {
            return {
                userName: 'Незарегистрированный пользователь',
                searchText: '',
                isShow: {
                    true: { display: 'block' },
                    false: {display : 'none'}
                }
            }
        },
        computed: {
            ...mapState('settings', ['settings']),
            ...mapState('user', ['currentUser']),
            ...mapState('preLoader', ['isActive']),
            GetApplicationName() {
                return this.searchSettingByName("Application.Name", "WebSite");
            },
            GetApplicationIcon() {
                return this.searchSettingByName("Application.Icon", "/images/layout_icons/header.png");
            }
        },
        methods: {
            ...mapActions('settings', ['GET_SETTINGS']),
            ...mapActions('user', ['GET_INFO_BY_CURRENT_USER']),
            ...mapMutations('menu', ['SET_OR_UPDATE_ACTIVE_CATEGORY']),
            searchNews() {
                if (Object.keys(this.$route.params).length == 0 || this.searchText != '') {
                    let routerParams = { name: 'search', params: { searchText: this.searchText } };
                    
                    if(this.$route.params.searchText != this.searchText) {
                        this.$router.push(routerParams);
                    }
                }
            },
            searchSettingByName(name, defaultName) {

                let item = this.settings.find(function (item) {
                    if (item.Name == name && item.Value != '') {
                        return item;
                    }
                });

                return typeof item == 'undefined' || item == null ? defaultName : item.Value

            },
            routerPushMainView() {
                if (this.$route.name != 'main' ) {
                    this.SET_OR_UPDATE_ACTIVE_CATEGORY(null);
                    this.$router.push('/');
                }
            },
            actionFocusin(e) {
                e.target.style.backgroundColor = 'white';
            },
            actionFocusout(e) {
                if(e.target.value.trim() != '')
                {
                    e.target.style.backgroundColor = 'white';
                }
                else {
                    e.target.style.backgroundColor = '#eeeeee';
                }
            }
        },
        mounted() {
            this.GET_SETTINGS();
            this.GET_INFO_BY_CURRENT_USER();
            
            let elem = document.querySelector('.inputSearch')
            let vm = this
            elem.addEventListener('focus', vm.actionFocusout.bind(this))
            elem.addEventListener('blur', vm.actionFocusin.bind(this))
        }
    }
</script>

<style lang="scss">
    .isActive {
        display:block;
    }

    .secondMenu {
        display: flex;
        padding-left: 0px;
        padding-right: 0px;

        &:last-child {
            display: flex;
            align-items: center;
            margin-left: auto;
        }
    }

    .headerMenu {
        display: flex;
        padding: 0px;

        &-search {
            display: flex;
            align-items: center;    
            flex-basis: 45%;  
            & .inputSearch {
                width: 50% !important;
            }  
        }

        & > li {

            &:last-child {
                margin-left: auto;
            }

        }

        &-user {
            padding:0;
            &__info {
                font-size:18px;
                padding-right:10px;
            }
            
            &__settings {

            }
        }
    }
</style>
