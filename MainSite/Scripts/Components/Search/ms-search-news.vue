<template>
  <div class="row">
    <button style="margin-top: 10px" class="btn btn-defaultMainSite" @click="toBack()">
      Вернуться назад
    </button>
    <div v-if="news.length">
      <msNewsItem
        v-for="(item, index) in news"
        :key="item.Id"
        :index="index"
        :isNews="IsNews"
        :news_item="item"
      />
    </div>
    <h4 v-else>По запросу: {{ this.$route.params.searchText }} ничего не найдено</h4>
  </div>
</template>

<script>
  import msNewsItem from '../News/ms-news-item.vue';
  import { mapState, mapActions } from 'vuex';

  export default {
    name: 'ms-search-news',
    components: {
      msNewsItem,
    },
    data() {
      return {};
    },
    watch: {
      $route: 'fetchData',
    },
    computed: {
      ...mapState('news', ['news']),
    },
    methods: {
      ...mapActions('news', ['GET_NEWS_BY_SEARCH']),
      fetchData() {
        this.GET_NEWS_BY_SEARCH(this.$route.params.searchText);
      },
      toBack() {
        this.$router.go(-1);
      },
    },
    created() {
      this.GET_NEWS_BY_SEARCH(this.$route.params.searchText);
    },
    beforeRouteUpdate(to, from, next) {
      if (to.path === from.path) {
        next(false);
      } else {
        console.log(to);
        console.log(from);
        next();
      }
    },
  };
</script>

<style></style>
