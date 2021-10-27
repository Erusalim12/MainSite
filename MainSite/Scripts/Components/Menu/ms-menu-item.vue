<template>
  <li>
    <router-link :title="menu_item.toolTip" :to="onClickTo()" :class="IsActive">
      <img v-if="GetPathImg" v-bind:src="GetPathImg" />
      <span v-else></span>
      <div>{{ menu_item.Name }}</div>
    </router-link>

    <!--<ul
        v-if="menu_item.children && menu_item.children.length"
        >
        <ms-menu-item v-for="item in menu_item.children"
                      :key="item.id"
                      :menu_item="item"
                      >

        </ms-menu-item>
    </ul>-->
  </li>
</template>
<script>
  import { mapState, mapMutations } from 'vuex';

  export default {
    name: 'ms-menu-item',
    props: {
      menu_item: {
        type: Object,
        default: () => {
          return {};
        },
      },
    },
    data: () => {
      return {
        activeClass: false,
      };
    },
    computed: {
      ...mapState('menu', ['activeCategoryId', 'breadcrumbs']),
      GetPathImg() {
        return this.menu_item.UrlIcon;
      },
      IsActive() {
        const currentBreadcrumb = this.breadcrumbs[0];
        const id = currentBreadcrumb && currentBreadcrumb.id;
        this.activeClass = id;

        return id === this.menu_item.Id ? 'active' : '';
      },
    },
    methods: {
      onClickTo() {
        if (this.menu_item.Children && this.menu_item.Children.length) {
          return {
            name: 'categoryList',
            params: { categoryId: this.menu_item.Id, category: this.menu_item },
          };
        } else {
          return { name: 'categoryDetails', params: { categoryId: this.menu_item.Id, page: 1 } };
        }
      },
    },
  };
</script>

<style scoped lang="scss">
  span {
    background-color: black;
    height: 2px;
    width: 30px;
  }
</style>
