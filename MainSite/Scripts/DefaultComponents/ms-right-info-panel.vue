<template>
  <div class="ms-right-panel">
    <ms-birthday />
    <ms-link-list />
  </div>
</template>

<script>
import msBirthday from "../Components/Birthday/ms-birthday.vue";
import msLinkList from "./ms-link-list.vue";

export default {
  name: "ms-right-info-panel",
  components: {
    msBirthday,
    msLinkList,
  },
};
</script>

<style lang="scss">
.ms-right-panel {
  width: 25%;
  position: absolute;
  right: 0;
  top: 0;
  margin: 0;
  transform: translateX(110%);

  @media (max-width: 992px) {
    margin: 0.5rem 0 1rem 0;
    transform: translateX(0px);
    position: inherit;
    width: 100%;
  }

  @media only screen and (min-width: 993px) and (max-width: 1700px) {
    width: 34%;
  }
}
</style>
