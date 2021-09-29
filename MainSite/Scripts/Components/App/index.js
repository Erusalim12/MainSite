﻿import Vue from 'vue';
import msMenu from '../Menu/ms-menu.vue';
import msHeader from '../Header/ms-header.vue';
import msFooter from '../Footer/ms-footer.vue';
import store from '../../Vuex/allStore';
import router from '../../Router/router';
import msMainWrapper from '../App/ms-main-wrapper.vue';
import VuModal from '../../DefaultComponents/Modal/main';

Vue.config.devtools = true;
new Vue({
    el:'#vueRootComponent',
    store,
    router,
    components: {
        msHeader,
        msMenu,
        msFooter,
        msMainWrapper,
        VuModal
    },
});
