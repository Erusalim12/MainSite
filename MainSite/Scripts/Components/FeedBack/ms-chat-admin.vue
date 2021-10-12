<template>
  <div>
    <div class="card card-panel question-menu row">
      <button class="btn btn-defaultMainSite danger" @click="onDeleteQuestion">Закончить диалог</button>
      <button class="btn btn-defaultMainSite" @click="onBack">Назад</button>
    </div>
    <ms-chat :questionId="this.$route.params.questionId" />
  </div>
</template>

<script>
  import msChat from '../FeedBack/ms-chat.vue'
  import msSimpleModal from '../../DefaultComponents/Modal/templates/ms-simple-modal'

  export default {
    name: 'ms-chat-admin',
    components: {
      msChat
    },
    methods: {
      onBack() {
        this.$router.push({name:'feedback'});
      },
      onDeleteQuestion() {
        this.$modals.open({
          title: "Вы уверены, что хотите завершить диалог?",
          bodyInfo: "Это действие невозможно будет отменить.",
          component: msSimpleModal,
          onClose: (data) => {
            if(data.ended) return false

            this.$http({
              method: 'post',
              url: '/api/question/deleteQuestion',
              params: {questionId : this.$route.params.questionId}
            })
            .then(res => {
              this.$router.push({name:'feedback'})
            })
            .catch(error => {
              M.toast({html: error})
            });
          }
        })
      }
    }
  }
</script>

<style lang="scss">
.btn-defaultMainSite.danger {
  border-color: red;
  color:red;
  &:hover {
    background-color: red;
    color:white;
  }
}
</style>