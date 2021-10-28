<template>
  <div class="card-panel ms-category-item" @click="onClickCategory()">
    <div :style="{ 'background-image': `url(${getPathImg})` }" class="ms-category-item_image"></div>
    <h5 class="text-center ms-category-item_title bold">
      {{ category_item.Name }}
    </h5>
  </div>
</template>

<script>
  import { mapMutations } from 'vuex';

  export default {
    name: 'ms-category-item',
    props: {
      category_item: {
        type: Object,
        default: () => {
          return {};
        },
      },
    },
    data() {
      return {};
    },
    computed: {
      getPathImg() {
        if (this.category_item.UrlIcon) {
          return this.category_item.UrlIcon;
        }

        return '/images/layout_icons/education.jpg';
      },
    },
    methods: {
      ...mapMutations('menu', ['ADD_BREADCRUMBS']),
      getNamePath() {
        if (this.category_item.Children.length > 0) {
          return 'categoryList';
        } else {
          return 'categoryDetails';
        }
      },
      getParamsPath() {
        const params = {};

        params.categoryId = this.category_item.Id;
        params.page = 1;
        if (this.category_item.Children.length > 0) {
          params.category = this.category_item;
        }

        return params;
      },
      onClickCategory() {
        this.ADD_BREADCRUMBS({ name: this.category_item.Name, id: this.category_item.Id });
        this.$router.push({ name: this.getNamePath(), params: this.getParamsPath() });
      },
    },
    mounted() {},
  };
</script>

<style lang="scss">
  .ms-category-item {
    overflow: hidden;
    height: 240px;
    width: 46%;
    @media (max-width: 900px) {
      width: 100%;
    }
    position: relative;
    margin: 10px 10px;
    cursor: pointer;
    z-index: 10;
    &:hover > &_title {
      text-decoration: underline;
      text-decoration-color: #64b5f6;
      text-decoration-thickness: 3px;
    }
    &_title {
      z-index: 5;
      position: absolute;
      padding: 0px 5px;
      margin: 0px;
      /* margin: 10px 10px; */
      width: 100%;
      top: 50%;
      left: 0;
      transform: translateY(-50%);
      color: white;
    }

    &_image {
      background-size: cover;
      overflow: hidden;
      position: absolute;
      top: 0;
      left: 0;
      z-index: 2;
      width: 100%;
      height: 100%;
      & > img {
        width: 100%;
        height: 100%;
        display: inline-block;
      }
      &:after {
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        height: 100%;
        width: 100%;
        background: radial-gradient(transparent, rgba(0, 0, 0, 0.85));
      }
    }
  }
</style>
