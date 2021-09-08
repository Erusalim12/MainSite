<template>
    <main role="main" class="col m12 s12 l9" id="mainBlock">
      <ms-modal-wrapper />      
      <router-view />
    </main>

</template>

<script>
    import msNews from '../News/ms-news.vue';
    import msModalWrapper from '../../DefaultComponents/Modal/ms-modal-wrapper';
    export default {
        name: 'ms-main-wrapper',
        components: {
            msNews,
            msModalWrapper
        },
        data() {
            return {}
        },
        mounted () {
        }
    }
</script>

<style lang="scss">
    .container {
        width: 60%;
    }
</style>
