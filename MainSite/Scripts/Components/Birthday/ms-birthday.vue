<template>
  <div v-if="birthdays && birthdays.length" class="card_birthday">
    <div class="card-panel">
      <div class="card_birthday-title bold">C днём рождения!</div>
      <div class="card_birthday-content">
        <div
          class="card_birthday-content_description"
          v-for="item in birthdays"
          :key="item.Id"
        >
          <span class="fio">{{ item.FIO }}</span>
          <span class="subdivision">{{ getSubDivision(item) }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  name: "ms-birthday",
  computed: {
    ...mapState("user", ["birthdays"]),
  },
  methods: {
    ...mapActions("user", ["GET_BIRTHDAYS"]),
    getSubDivision(subDivision) {
      if (typeof subDivision == "undefined" || subDivision == null)
        return "Подразделение";

      return subDivision.DepartmentShortName !== ""
        ? subDivision.DepartmentShortName
        : subDivision.DepartmentFullName;
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
      padding-bottom: 15px;
      width: 100%;
    }
  }

  &-content {
    font-size: 14px;
    display: flex;
    flex-direction: column;
    @media (max-width: 1400px) {
      flex-direction: row;
      flex-wrap: wrap;
      justify-content: inherit !important;
    }
    &_description {
      display: flex;
      flex-wrap: wrap;
      @media (max-width: 1400px) {
        padding: 5px;
      }
      .fio {
        padding-right: 10px;
        font-weight: 600;
        /*flex-basis:70%;*/
        @media (max-width: 1400px) {
          flex-basis: inherit;
        }
      }
      .subdivision {
        font-style: italic;
        /*flex-basis:30%;*/
        @media (max-width: 1400px) {
          flex-basis: inherit;
        }
      }
    }
  }
}
</style>
