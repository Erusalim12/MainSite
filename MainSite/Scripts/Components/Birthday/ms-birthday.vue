<template>
  <div v-if="birthdays && birthdays.length" class="card_birthday">
    <div class="card-panel">
      <div class="card_birthday-title bold">C днём рождения!</div>
      <ms-birthday-info :list="birthdays[0]" title="сегодня" />
      <hr />
      <template v-if="birthdays[1]">
        <transition name="fade">
          <template v-if="isShowInfo">
            <ms-birthday-info :list="birthdays[1]" title="завтра" />
          </template>
        </transition>
        <div style="text-align: center">
          <div @click="onShowInfoTommorow" class="btnTomorrowBirthdays">
            <span>{{ titleBtnBirthdays }}</span>
            <span class="material-icons">{{ titleKeyboard }}</span>
          </div>
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
    titleKeyboard() {
      return this.isShowInfo ? "keyboard_arrow_up" : "keyboard_arrow_down";
    },
    titleBtnBirthdays() {
      return this.isShowInfo ? "Cвернуть" : "Развернуть";
    },
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

<style lang="scss" scoped>
/*Оформление блока день рождение(birthday)*/
.card_birthday {
  .card-panel {
    margin-top: 0px;
  }

  &-title {
    cursor: pointer;
    text-align: center;
    color: #b12344;
    padding-bottom: 5px;
    @media (max-width: 1400px) {
      text-align: center;
      width: 100%;
    }
  }

  .btnTomorrowBirthdays {
    display: inline-flex;
    align-items: center;
    * {
      font-size: 12px;
      cursor: pointer;
    }
    padding: 2px;
    margin: 10px 0px 10px 0px;
    color: #64b5f6;
  }

  .fade-enter-active,
  .fade-leave-active {
    transition: all 0.6s ease;
    max-height: 700px;
  }
  .fade-enter,
  .fade-leave-to {
    transform: translateX(10px);
    opacity: 0;
    max-height: 0px;
  }
}
</style>
