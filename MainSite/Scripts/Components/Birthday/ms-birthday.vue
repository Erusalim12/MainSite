<template>
  <div v-if="birthdays && birthdays.length" class="card_birthday">
    <div class="card-panel">
      <div class="card_birthday-title bold">C днём рождения!</div>
      <ms-birthday-info :list="birthdays[0]" title="сегодня" />
      <hr />
      <template v-if="birthdays[1]">
        <template v-if="isShowInfo">
          <ms-birthday-info :list="birthdays[1]" title="завтра" />
        </template>
        <div
          @click="onShowInfoTommorow"
          class="card_birthday-title bold btnTomorrowBirthdays"
          style="cursor: pointer"
        >
          На завтра
        </div>
      </template>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from "vuex";

import msBirthdayInfo from "./ms-birthday-info.vue";

export default {
  name: "ms-birthday",
  components: { msBirthdayInfo },
  data() {
    return {
      isShowInfo: false,
    };
  },
  computed: {
    ...mapState("user", ["birthdays"]),
  },
  methods: {
    ...mapActions("user", ["GET_BIRTHDAYS"]),
    onShowInfoTommorow() {
      this.isShowInfo = !this.isShowInfo;
    },
  },
  mounted() {
    if (!this.birthdays.length) this.GET_BIRTHDAYS();
  },
};
</script>

<style lang="scss">
/*Оформление блока день рождение(birthday)*/
.card_birthday {
  .card-panel {
    margin-top: 0px;
  }

  &-title {
    text-align: center;
    color: #b12344;
    padding-bottom: 5px;
    @media (max-width: 1400px) {
      text-align: center;
      width: 100%;
    }

    &.btnTomorrowBirthdays {
      border: 1px solid #b12344;
      border-radius: 8px;
      padding: 5px;
      margin: 10px 0px 10px 0px;
      &:hover {
        background-color: #b12344;
        color: #fff;
      }
    }
  }
}
</style>
