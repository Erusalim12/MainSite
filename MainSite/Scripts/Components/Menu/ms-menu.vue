<template>
  <ul class="menu">
    <li>
      <router-link :to="{ name: 'main' }" :class="{ active: $route.path === '/' }">
        <img src="/images/layout_icons/newsfeed.svg" />
        <div class="bold">Новости</div>
      </router-link>
    </li>
    <ms-menu-item v-for="category in categories" :key="category.id" :menu_item="category">
    </ms-menu-item>
  </ul>
</template>

<script>
  import msMenuItem from './ms-menu-item.vue';
  import { mapActions, mapState, mapMutations } from 'vuex';

  export default {
    name: 'ms-menu',
    data() {
      return {
        categoryId: undefined,
      };
    },
    components: {
      msMenuItem,
    },
    computed: {
      ...mapState('menu', ['categories', 'breadcrumbs']),
    },
    methods: {
      ...mapActions('menu', ['GET_CATEGORIES']),
      searchSettingByName(name, defaultName) {
        let item = this.settings.find(function (item) {
          if (item.Name == name && item.Value != '') {
            return item;
          }
        });

        return typeof item == 'undefined' || item == null ? defaultName : item.Value;
      },
    },
    created() {
      this.GET_CATEGORIES();
    },
  };
</script>

<style scoped lang="scss">
  .rectangle {
    background-color: white;
  }
</style>
