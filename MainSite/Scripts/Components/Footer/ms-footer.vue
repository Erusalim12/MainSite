<template>
  <footer>
    <nav>
      <div class="container">
        <router-link class="bold" to="/feedback"
          >Сообщить о проблеме или высказать пожелание
        </router-link>
        <div
          v-html="GetInfoFooter"
          style="display: flex; justify-content: space-between; flex-wrap: wrap"
        ></div>
      </div>
    </nav>
  </footer>
</template>

<script>
  import { mapState } from 'vuex';

  export default {
    name: 'ms-footer',
    computed: {
      ...mapState('settings', ['settings']),
      GetApplicationCopy() {
        return this.searchSettingByName(
          'Application.Copy',
          'Разработка информационного портала. 2021',
        );
      },
      GetApplicationAdditionalInfo() {
        let result = this.searchSettingByName('Application.AdditionalInfo', '');

        return result ? `<div>${result}</div>` : '';
      },
      GetInfoFooter() {
        return `${this.GetApplicationAdditionalInfo} <div>${this.GetApplicationCopy}</div>`;
      },
    },
    methods: {
      searchSettingByName(name, defaultName) {
        let item = this.settings.find(function (item) {
          if (item.Name == name && item.Value != '') {
            return item;
          }
        });

        return typeof item == 'undefined' || item == null ? defaultName : item.Value;
      },
    },
  };
</script>

<style lang="scss"></style>
