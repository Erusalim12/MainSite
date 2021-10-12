<template>
  <div class="card_birthday">
    <div v-if="users && users.length" class="card-panel">
      <div class="card_birthday-title bold">C днём рождения!</div>
      <div class="card_birthday-content">
        <div class="card_birthday-content_description" v-for="item in users" :key="item.Id">
          <span class="fio">{{ item.FIO }}</span>
          <span class="subdivision">{{ getSubDivision(item) }}</span>
        </div>
      </div>
    </div>
    <ul class="menu">
      <li>
        <a :href="getLinkUrl" style="padding-left: 0px" v-html="getLinkInfo" />
      </li>
    </ul>
  </div>
</template>

<script>
  import axios from 'axios';
  import { mapState } from 'vuex';

  export default {
    data() {
      return {
        users: [],
      };
    },
    computed: {
      ...mapState('settings', ['settings']),
      getLinkName() {
        return `<div class="bold">${this.searchSettingByName(
          'Link.Name',
          'Ссылка на ресурс',
        )}</div>`;
      },
      getLinkUrl() {
        return this.searchSettingByName('Link.Url', '#');
      },
      getLinkIcon() {
        let icon = this.searchSettingByName('Link.Icon', null);
        if (icon) return `<img src="${icon}" />`;

        return `<span class='rectangle' style='background-color: white'></span>`;
      },
      getLinkInfo() {
        return this.getLinkIcon + this.getLinkName;
      },
    },
    methods: {
      setUsers() {
        axios('/api/ApiUsers/GetBirthdayUsers', {
          method: 'GET',
        }).then((responce) => {
          this.users = responce.data;
        });
      },
      getSubDivision(subDivision) {
        if (typeof subDivision == 'undefined' || subDivision == null) return 'Подразделение';

        return subDivision.DepartmentShortName !== ''
          ? subDivision.DepartmentShortName
          : subDivision.DepartmentFullName;
      },
      searchSettingByName(name, defaultName) {
        let item = this.settings.find(function (item) {
          if (item.Name == name && item.Value != '') {
            return item;
          }
        });

        return typeof item == 'undefined' || item == null ? defaultName : item.Value;
      },
    },
    mounted() {
      this.setUsers();
    },
  };
</script>

<style lang="scss">
  /*Оформление блока день рождение(birthday)*/
  .card_birthday {
    .card-panel {
      margin-top: 0px;
    }

    position: absolute;
    right: 0;
    top: 0;
    margin: 0;
    transform: translateX(110%);
    width: 25%;

    @media (max-width: 900px) {
      margin: 0.5rem 0 1rem 0;
      transform: translateX(0px);
      position: inherit;
      width: 100%;
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
