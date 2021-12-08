<template>
  <ul v-if="externalLinks.length" class="card card-panel">
    <li v-for="item in externalLinks" :key="item.name">
      <a target="_blank" :href="item.url">
        <img v-if="item.pathIcon" width="40" height="40" :src="item.pathIcon" />
        <div v-html="item.name"></div>
        <i class="material-icons">keyboard_arrow_right</i>
      </a>
    </li>
  </ul>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  name: "ms-link-list",
  computed: {
    ...mapState("externalLinks", ["externalLinks"]),
  },
  methods: {
    ...mapActions("externalLinks", ["GET_EXTERNAL_LINKS"]),
  },
  mounted() {
    if (!this.externalLinks.length) this.GET_EXTERNAL_LINKS();
  },
};
</script>

<style lang="scss" scoped>
.card {
  padding: 0px !important;
  overflow: hidden;
  margin-top: 0em;
  li {
    border-bottom: 1px solid rgba(0, 0, 0, 0.04);
    position: relative;

    display: flex;
    justify-content: space-between;
    align-items: center;

    &:hover {
      background: rgba(0, 0, 0, 0.04);
    }

    &:last-child {
      border: none;
    }
  }
  a {
    display: flex;
    width: 100%;
    align-items: center;

    i {
      margin-left: auto;
    }

    div {
      margin-right: 10px;
      margin-left: 10px;
    }

    font-size: 12px;
    font-weight: 600;
    color: #9e9e9e;
    padding: 10px 0px 10px 15px;
    min-height: 60px;
  }
}
</style>
