<template>
  <header class="navbar-fixed">
    <nav class="nav-header">
      <div class="container">
        <div class="nav-wrapper">
          <div class="valign-wrapper">
            <a
              style="cursor: pointer"
              @click="routerPushMainView"
              class="valign-wrapper"
            >
              <img :src="GetApplicationIcon" width="50" height="50" />
              <span
                class="bold"
                style="
                  padding-left: 10px;
                  line-height: 15px;
                  margin-right: 13px;
                  font-size: 12px;
                "
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
                <input
                  v-model="searchText"
                  class="inputTextMainSite"
                  type="text"
                />
                <button class="btn btn-default" @click="searchNews">
                  Найти
                </button>
              </div>
              <div class="valign-wrapper" style="justify-content: flex-end">
                <span class="headerMenu-user__info">
                  <div v-if="messageInfo">
                    <i class="material-icons">message</i>
                    {{ messageInfo }}
                  </div>
                  {{ currentUser.Name }}
                </span>
              </div>
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
      messageInfo: "",
    };
  },
  computed: {
    ...mapState("settings", ["settings"]),
    ...mapState("user", ["currentUser"]),
    ...mapState("preLoader", ["isActive"]),
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
    this.$http("/api/Question/newMessage").then((res) => {
      this.messageInfo = res.data ? res.data.messageInfo : 0;
    });
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
      display: flex;
      font-size: 14px;
      div {
        padding-right: 5px;
        display: flex;
        align-items: baseline;
      }
    }
  }
}
</style>
