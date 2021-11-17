import Vue from "vue";
import msMenu from "../Menu/ms-menu.vue";
import msHeader from "../Header/ms-header.vue";
import store from "../../Vuex/allStore";
import router from "../../Router/router";
import msMainWrapper from "../App/ms-main-wrapper.vue";
import VuModal from "../../DefaultComponents/Modal/main";
import msFooter from "../Footer/ms-footer.vue";
import axios from "axios";
import QuestionHubPlugin from "../../Plugins/question-hub";

import Tooltip from "vue-directive-tooltip";
import "vue-directive-tooltip/dist/vueDirectiveTooltip.css";

Vue.use(Tooltip);

Vue.prototype.$http = axios;
axios.defaults.baseURL = `${window.location.protocol + "//"}${
  window.location.host
}`;

Vue.use(QuestionHubPlugin);
Vue.config.devtools = true;

new Vue({
  el: "#vueRootComponent",
  store,
  router,
  components: {
    msHeader,
    msFooter,
    msMenu,
    msMainWrapper,
    VuModal,
  },
});
