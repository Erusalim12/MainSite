<template>
  <header class="navbar-fixed">
    <nav class="nav-header">
      <div class="container">
        <div class="nav-wrapper">
          <div class="valign-wrapper">
            <a style="cursor: pointer" @click="routerPushMainView" class="valign-wrapper">
              <img :src="GetApplicationIcon" width="50" height="50" />
              <span
                class="bold"
                style="padding-left: 10px; line-height: 15px; margin-right: 13px; font-size: 12px"
                v-html="GetApplicationName"
              ></span>
            </a>
            <a
              id="openMenu"
              data-target="mobile-demo"
              class="sidenav-trigger"
              style="float: right; cursor: pointer"
              ><i class="material-icons">menu</i></a
            >
            <div class="hide-on-med-and-down col m12 s12 l9 headerMenu">
              <div class="col l6 headerMenu-search">
                <span class="bold">Поиск:</span>
                <input v-model="searchText" class="inputTextMainSite" type="text" />
                <button class="btn btn-default" @click="searchNews">Найти</button>
              </div>
              <a
                data-target="dropdown1"
                class="dropdown-trigger valign-wrapper"
                style="justify-content: flex-end"
              >
                <span class="headerMenu-user__info">{{ currentUser.Name }}</span>
                <!--<img src="/images/layout_icons/userLogout.svg" alt="" />-->
              </a>
              <ul class="menu menu-link">
                <li style="padding: 0" v-html="getLinkInfo"></li>
              </ul>
              <!--<ul id='dropdown1' class='dropdown-content headerMenu-user__settings'>
								<li><a href="#!"><i class="material-icons">home</i>Личный кабинет</a></li>
								<li><a href="#!"><i class="material-icons">cloud</i>Управление сервисами</a></li>
							</ul>-->
            </div>
          </div>
        </div>
      </div>
      <div
        class="progress"
        id="progressLoad"
        style="background-color: transparent; margin: 0px"
        v-bind:style="isShow[isActive]"
      >
        <div class="indeterminate" style="background-color: #64b5f6"></div>
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
          false: { display: 'none' },
        },
      };
    },
    computed: {
      ...mapState('settings', ['settings']),
      ...mapState('user', ['currentUser']),
      ...mapState('preLoader', ['isActive']),
      ...mapState('settings', ['settings']),
      getLinkName() {
        return `<div class="bold">${this.searchSettingByName(
          'Link.Name',
          'Ссылка на ресурс',
        )}</div>`;
      },
      getLinkUrl() {
        return this.searchSettingByName('Link.Url', '#');
      },
      getLinkIcon() {
        let icon = this.searchSettingByName('Link.Icon', null);
        if (icon) return `<img src="${icon}" />`;

        return `<span class='rectangle' style='background-color: white'></span>`;
      },
      getLinkInfo() {
        return `<a href="${this.getLinkUrl}">${this.getLinkIcon + this.getLinkName}</a>`;
      },
      GetApplicationName() {
        return this.searchSettingByName('Application.Name', 'WebSite');
      },
      GetApplicationIcon() {
        return this.searchSettingByName('Application.Icon', '/images/layout_icons/header.png');
      },
    },
    methods: {
      ...mapActions('settings', ['GET_SETTINGS']),
      ...mapActions('user', ['GET_INFO_BY_CURRENT_USER']),
      ...mapMutations('menu', ['SET_OR_UPDATE_ACTIVE_CATEGORY']),
      searchNews() {
        if (this.searchText !== this.$route.params.searchText) {
          this.$router.push({ name: 'search', params: { searchText: this.searchText } });
        }
        this.searchText = '';
      },
      searchSettingByName(name, defaultName) {
        let item = this.settings.find(function (item) {
          if (item.Name == name && item.Value != '') {
            return item;
          }
        });

        return typeof item == 'undefined' || item == null ? defaultName : item.Value;
      },
      routerPushMainView() {
        if (this.$route.name != 'main') {
          this.SET_OR_UPDATE_ACTIVE_CATEGORY(null);
          this.$router.push('/');
        }
      },
    },
    mounted() {
      this.GET_SETTINGS();
      this.GET_INFO_BY_CURRENT_USER();
    },
    created() {
      this.$questionHub.connetionAdminOpened();
    },
    beforeDestroy() {
      this.$questionHub.connetionAdminClosed();
    },
  };
</script>

<style lang="scss">
  .isActive {
    display: block;
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
    padding: 0 !important;

    &-search {
      display: flex;
      align-items: center;
      padding-left: 0px !important;
      margin-left: 0;

      & > span {
        margin-right: 5px;
      }

      & > .inputTextMainSite {
        margin-right: 5px;
        max-width: calc(100% - 150px);
        border-radius: 8px 0px 0px 8px !important;
        border-right: none !important;
      }

      & > .btn-default {
        border-radius: 0px 8px 8px 0px !important;
      }
    }

    & > li {
      &:last-child {
        margin-left: auto;
      }
    }

    &-user {
      padding: 0;
      &__info {
        font-size: 14px;
      }

      &__settings {
      }
    }
  }
</style>
