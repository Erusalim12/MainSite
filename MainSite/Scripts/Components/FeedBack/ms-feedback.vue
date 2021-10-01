<template>
  <div class="row">
    <div class="card-panel" style="display:flex;align-items:center;">
      <h5>Указать проблему и начать диалог</h5>
      <button 
        @click="openAddQuestionModal" 
        class="btn btn-defaultMainSite"
        style="margin-left:auto;"
      >
        <i class="fas fa-plus"/> Указать проблему
      </button>
    </div>
    <input type="text" v-model="this.currentUser.type" />
    <ul class="list-group question-previews mt-4">
      <question-preview
        v-for="question in questions"
        :key="question.id"
        :question="question"
        class="list-group-item list-group-item-action mb-3" />
    </ul>
  </div>
</template>
 
<script>    
import QuestionPreview from './question-preview'
import FeedBackQuestionModal from '../../DefaultComponents/Modal/templates/ms-feedback-question-modal.js'

import {mapState} from 'vuex' 

export default {
  name: 'ms-feedback',
  components: {
    QuestionPreview
  },
  data () {
    return {
      questions: []
    }
  },
  computed: {
    ...mapState('user', ['currentUser']),
  },
  methods: {
    onQuestionAdded (question) {
      this.questions = [question, ...this.questions]
    },
    openAddQuestionModal() {
      let vm = this;

      this.$modals.open({
          component: FeedBackQuestionModal,
          onClose(newQuestion) {
              vm.questions = [newQuestion, ...vm.questions]
          }
      })
    }
  },
  created () {
    this.$http.get('/api/Question/question').then(res => {
      this.questions = res.data
      this.$questionHub.questionOpened(this.currentUser.Id, this.currentUser.IsAdmin)
    })
  },
  beforeDestroy() {
    this.$questionHub.questionClosed(this.currentUser.Id)
  },
}
</script>
 
<style lang="scss" scoped>
.question-previews .list-group-item{
  cursor: pointer;
}
#mainBlock {
  padding:0 !important;
}
</style>