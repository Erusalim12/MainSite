<template>
  <div style="margin:0px;">
    <h4>
      Указать проблему и начать диалог
      <button v-b-modal.addQuestionModal class="btn btn-primary mt-2 float-right">
        <i class="fas fa-plus"/> Указать проблему
      </button>
    </h4>
    <ul class="list-group question-previews mt-4">
      <question-preview
        v-for="question in questions"
        :key="question.id"
        :question="question"
        class="list-group-item list-group-item-action mb-3" />
    </ul>
    <add-question-modal @question-added="onQuestionAdded"/>
  </div>
</template>
 
<script>    
import QuestionPreview from './question-preview'
import AddQuestionModal from './add-question-modal'
import {mapState} from 'vuex' 
export default {
  name: 'ms-feedback',
  components: {
    QuestionPreview,
    AddQuestionModal
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
 
<style lang="scss">
.question-previews .list-group-item{
  cursor: pointer;
}
</style>