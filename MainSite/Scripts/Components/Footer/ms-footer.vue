<template>
  <footer>
    <nav>
      <div class="container">
        <router-link class="bold" to="/feedback">Сообщить о проблеме или высказать пожелание</router-link>
        <br />
        <span>{{GetApplicationCopy}}</span>
      </div>
    </nav>
  </footer>
</template>

<script>
    import {mapState} from 'vuex';

    export default {
        name: 'ms-footer',
        computed: {
          ...mapState('settings', ['settings']),
          GetApplicationCopy() {
            return this.searchSettingByName("Application.Copy", "Разработка информационного портала. 2021");
          }
        },
        methods: {
          searchSettingByName(name, defaultName) {
            let item = this.settings.find(function (item) {
              if (item.Name == name && item.Value != '') {
                return item;
              }
            });

            return typeof item == 'undefined' || item == null ? defaultName : item.Value
          },
        }
    }
</script>

<style lang="scss">

</style>
