<template>
  <div class="row" style="position: relative">
    <ms-calendar />
    <ms-right-info-panel />
    <!--<msCreaterNewsItem :categoryId="$route.params.categoryId" />-->
    <msNewsList />
  </div>
</template>

<script>
  import msNewsList from './ms-news-list.vue';
  import msCreaterNewsItem from './ms-creater_news-item.vue';
  import msRightInfoPanel from '../../DefaultComponents/ms-right-info-panel.vue';
  import msCalendar from '../Calendar/ms-calendar.vue';

  export default {
    name: 'ms-news',
    components: {
      msNewsList,
      msCreaterNewsItem,
      msRightInfoPanel,
      msCalendar,
    },
  };
</script>

<style scoped lang="scss"></style>
