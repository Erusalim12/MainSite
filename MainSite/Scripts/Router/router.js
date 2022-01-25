import Vue from 'vue';
import Router from 'vue-router';

import msNews from '../Components/News/ms-news.vue';
import msNewsByCategory from '../Components/News/ms-news-category';
import msSearchNews from '../Components/Search/ms-search-news.vue';

import msCategory from '../Components/Category/ms-category.vue';
import msCategoryList from '../Components/Category/ms-category-list.vue';
import msCategoryItemCreate from '../Components/Category/ms-category-item_create.vue';

import msFeedBack from '../Components/FeedBack/ms-feedback.vue';
import msChatAdmin from '../Components/FeedBack/ms-chat-admin.vue';

import msSchedule from '../Components/Schedule/ms-schedule.vue';

Vue.use(Router);

let router = new Router({
  //mode:'history',
  routes: [
    {
      path: '/',
      name: 'main',
      component: msNews,
      children: [
        {
          path: '/page=:page',
          name: 'news',
          component: msNews,
          props: true,
        },
      ],
    },
    {
      path: '/search/searchText=:searchText',
      name: 'search',
      component: msSearchNews,
      props: true,
    },
    {
      path: '/feedback',
      component: msFeedBack,
      name: 'feedback',
      props: true,
    },
    {
      path: '/adminChat/:questionId',
      name: 'adminChat',
      component: msChatAdmin,
      props: false,
    },    
    {
      path: '/Schedule/ForCursants',
      name: 'schedule',
      component: msSchedule,
      props:true
    },
    {
      path: '/category',
      name: 'category',
      component: msCategory,
      children: [
        {
          path: '/category/:categoryId',
          name: 'categoryList',
          component: msCategoryList,
          props: true,
          children: [
            {
              path: '/category/:categoryId/:subCategoryId',
              component: msCategoryList,
              props: true,
            },
          ],
        },
        {
          path: '/categoryDetails/:categoryId/page=:page',
          name: 'categoryDetails',
          component: msNewsByCategory,
          props: true,
        },
        {
          path: '/create/parentCategoryId=:parentCategoryId',
          name: 'createCategory',
          component: msCategoryItemCreate,
          props: true,
        },
      ],
      props: true,
    },
  ],
});

export default router;
