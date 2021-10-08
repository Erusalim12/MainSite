<template>
  <Component :is="getComponent"/>
</template>
 
<script>    
import msFeedBackAdmin from './ms-feedback-admin.vue';
import msFeedBackUser from './ms-feedback-user.vue';
import {mapState} from 'vuex' 

export default {
  name: 'ms-feedback',
  components: {
    msFeedBackAdmin,
    msFeedBackUser
  },
  computed: {
    ...mapState('user', ['currentUser']),
    getComponent () {
      const components =  {
        admin : msFeedBackAdmin, 
        user: msFeedBackUser, 
      }

      return components[this.getRoleUser]
    },
    getRoleUser() {
      return this.currentUser.IsAdmin ? 'admin': 'user'
    },
  }
}
</script>
 
<style lang="scss" scoped>
#mainBlock {
  padding:0 !important;
}
</style>