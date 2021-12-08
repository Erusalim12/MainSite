<template>
  <header class="navbar-fixed">
    <nav class="nav-header">
      <div class="container">
        <div class="nav-wrapper">
          <div class="wrapper_backround">&nbsp;</div>
          <div class="valign-wrapper">
            <a
              style="cursor: pointer; z-index: 5; min-width: 300px"
              @click="routerPushMainView"
              class="valign-wrapper"
            >
              <img :src="GetApplicationIcon" width="50" height="50" />
              <span class="header_name" v-html="GetApplicationName"></span>
            </a>
            <a
              id="openMenu"
              data-target="mobile-demo"
              class="sidenav-trigger"
              style="float: right; cursor: pointer"
              ><i class="material-icons">menu</i></a
            >
            <div class="hide-on-med-and-down col m12 s12 l9 headerMenu">
              <div class="imgLogo">
                <div class="imgLogo__wrapper">&nbsp;</div>
              </div>
              <div class="headerMenu-search">
                <span>Поиск:</span>
                <input
                  v-model="searchText"
                  v-on:keyup.enter="searchNews"
                  class="inputTextMainSite"
                  type="text"
                />
                <button class="btn btn-default" @click="searchNews">
                  Найти
                </button>
              </div>
              <span class="headerMenu-user__info">
                <router-link style="color: #b12344" to="/feedback">
                  <span v-if="messageInfo">
                    <i
                      class="material-icons"
                      title="Имеются непрочитанные сообщения"
                      >message</i
                    >
                    {{ messageInfo }}
                  </span>
                  <i
                    class="material-icons"
                    title="Сообщить о проблеме или высказать пожелание"
                    v-else
                    >contact_support</i
                  >
                </router-link>
                {{ currentUser.Name }}
              </span>
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
import { mapState, mapActions, mapMutations } from "vuex";

export default {
  name: "ms-header",
  data() {
    return {
      userName: "Незарегистрированный пользователь",
      searchText: "",
      isShow: {
        true: { display: "block" },
        false: { display: "none" },
      },
    };
  },
  computed: {
    ...mapState("settings", ["settings"]),
    ...mapState("user", ["currentUser"]),
    ...mapState("preLoader", ["isActive"]),
    ...mapState("feedBack", ["messageInfo"]),
    GetApplicationName() {
      return this.searchSettingByName("Application.Name", "WebSite");
    },
    GetApplicationIcon() {
      return this.searchSettingByName(
        "Application.Icon",
        "/images/layout_icons/header.png"
      );
    },
  },
  methods: {
    ...mapActions("settings", ["GET_SETTINGS"]),
    ...mapActions("user", ["GET_INFO_BY_CURRENT_USER"]),
    ...mapActions("feedBack", ["GET_MESSAGE_INFO"]),
    ...mapMutations("menu", ["SET_OR_UPDATE_ACTIVE_CATEGORY"]),
    searchNews() {
      if (this.searchText !== this.$route.params.searchText) {
        this.$router.push({
          name: "search",
          params: { searchText: this.searchText },
        });
      }
      this.searchText = "";
    },
    searchSettingByName(name, defaultName) {
      let item = this.settings.find(function (item) {
        if (item.Name == name && item.Value != "") {
          return item;
        }
      });

      return typeof item == "undefined" || item == null
        ? defaultName
        : item.Value;
    },
    routerPushMainView() {
      if (this.$route.name != "main") {
        this.SET_OR_UPDATE_ACTIVE_CATEGORY(null);
        this.$router.push("/");
      }
    },
  },
  mounted() {
    this.GET_SETTINGS();
    this.GET_INFO_BY_CURRENT_USER();
  },
  created() {
    this.$questionHub.connetionAdminOpened();
    this.GET_MESSAGE_INFO();
  },
  beforeDestroy() {
    this.$questionHub.connetionAdminClosed();
  },
};
</script>

<style lang="scss">
.wrapper_backround {
  position: absolute;
  width: 109%;
  transform: translateX(-4%);
  z-index: 0;
  height: 100%;
  background: linear-gradient(
    90deg,
    rgba(255, 255, 255, 1) 0%,
    rgba(128, 193, 255, 1) 20%,
    rgba(129, 194, 255, 1) 80%,
    rgba(255, 255, 255, 1) 100%
  );
}

header {
  box-shadow: none !important;
  .nav-header {
    box-shadow: 0 0px 0px 0 black, 0 0px 0px 0px black, 0 0px 6px 0 black !important;
  }

  .header_name {
    color: rgb(212, 234, 55);
    text-shadow: 1px 0 0 #424242, -2px 0 0 #424242, 0 2px 0 #424242,
      0 -2px 0 #424242, 1px 1px #424242, -1px -1px 0 #424242, 1px -1px 0 #424242,
      -1px 1px 0 #424242;
    padding-left: 10px;
    line-height: 15px;
    margin-right: 13px;
    font-size: 12px;
  }

  .imgLogo {
    z-index: 0;
    object-fit: contain;
    position: absolute;
    height: 64px;
    background-image: url(/images/layout_icons/structure.jpg);
    background-size: contain;
    background-repeat: no-repeat;
    width: 300px;
    left: 20%;

    &__wrapper {
      background: linear-gradient(
        90deg,
        rgba(128, 193, 255, 1) 5%,
        transparent 20%,
        transparent 80%,
        rgba(128, 193, 255, 1) 95%
      );
    }
  }

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
    z-index: 1;
    padding: 0 !important;

    &-search {
      display: flex;
      align-items: center;
      padding-left: 0px !important;
      margin-left: auto;
      width: 75%;
      z-index: 1;
      position: relative;
      color: black;
      & > span {
        margin-right: 5px;
      }

      & > .inputTextMainSite {
        margin-right: 10px !important;
        background-color: white !important;
        max-width: calc(100% - 150px);
        color: black !important;
      }

      & > .btn-default {
        color: black;
        &:hover {
          background-color: #64b5f6;
          color: white;
        }
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
        display: flex;
        font-size: 14px;
        transform: translateX(107%);
        position: absolute;
        top: 0;
        right: 0;
        width: 34%;
        a {
          padding-right: 5px;
          display: flex;
          span {
            display: flex;
            align-items: baseline;
          }
        }
      }
    }
  }
}
</style>
