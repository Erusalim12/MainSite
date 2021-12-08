<template>
  <div class="card_birthday-content">
    <div
      v-if="title"
      class="card_birthday-content_title"
      v-html="`<b>${title}</b>${list.length ? '' : '<br/> именинников нет'}`"
    ></div>
    <div
      class="card_birthday-content_description"
      v-for="item in list"
      :key="item.id"
    >
      <span class="fio">{{ item.fio }}</span>
      <span class="subdivision">{{ getSubDivision(item) }}</span>
    </div>
  </div>
</template>

<script>
export default {
  name: "ms-birthday-info",
  props: {
    list: {
      type: Array,
      default: () => {
        return [];
      },
    },
    title: {
      type: String,
      default: () => {
        return "";
      },
    },
  },
  methods: {
    getSubDivision(subDivision) {
      if (typeof subDivision == "undefined" || subDivision == null)
        return "Подразделение";

      return subDivision.departmentShortName !== ""
        ? subDivision.departmentShortName
        : subDivision.departmentFullName;
    },
  },
};
</script>

<style lang="scss" scoped>
/*Оформление блока день рождение(birthday)*/
.card_birthday {
  &-content {
    font-size: 14px;
    display: flex;
    flex-direction: column;
    @media (max-width: 1400px) {
      /*flex-direction: row;*/
      flex-wrap: wrap;
    }
    &_title {
      display: block;
      margin-bottom: 10px;
    }
    &_description {
      display: flex;
      flex-wrap: wrap;
      justify-content: space-between;
      @media (max-width: 1400px) {
        padding: 5px;
        font-size: 12px;
      }
      .fio {
        padding-right: 10px;
        font-weight: 600;
        @media (max-width: 1400px) {
          //flex-basis: inherit;
        }
      }
      .subdivision {
        font-style: italic;
        @media (max-width: 1400px) {
          //flex-basis: inherit;
        }
      }
    }
  }
}
</style>
