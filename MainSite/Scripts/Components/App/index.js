import Vue from "vue";
import msMenu from "../Menu/ms-menu.vue";
import msHeader from "../Header/ms-header.vue";
import store from "../../Vuex/allStore";
import router from "../../Router/router";
import msMainWrapper from "../App/ms-main-wrapper.vue";
import VuModal from "../../DefaultComponents/Modal/main";
import msFooter from "../Footer/ms-footer.vue";
import QuestionHubPlugin from "../../Plugins/question-hub";

import Tooltip from "vue-directive-tooltip";
import "vue-directive-tooltip/dist/vueDirectiveTooltip.css";

DOMTokenList.prototype.replace = function (a, b) {
  var arr = Array(this);
  var regex = new RegExp(arr.join("|").replace(/ /g, "|"), "i");
  if (!regex.test(a)) {
    return this;
  }
  this.remove(a);
  this.add(b);
  return this;
};

Vue.use(Tooltip);
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
