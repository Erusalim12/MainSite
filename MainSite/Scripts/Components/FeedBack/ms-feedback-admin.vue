<template>
  <div class="row">
    <template v-if="questions.length">   
      <h5>Список обращений от пользователей</h5>
      <ms-question-preview
        v-for="question in questions"
        :key="question.id"
        :question="question"
      />
    </template>
    <template v-else>
      <h5>Список проблем и пожеланий от пользователей отсутствует</h5>
    </template>
  </div>
</template>

<script>
  import msQuestionPreview from '../FeedBack/ms-question-preview.vue'

  export default {
    name: 'ms-feedback-admin',
    components: {
      msQuestionPreview
    },
    data() {
      return {
        questions: []
      }
    },
    methods: {
      onQuestionAdded (question) {
        if (!this.questions.find(a => a.id === question.id)) {
          this.questions = [Object.assign(question, {answerCount: question.answers.length}), ...this.questions]
        }
      }
    },
    created () {
      this.$http.get('/api/Question/question').then(res => {
        this.questions = res.data
      })
      this.$questionHub.$on('question-added', this.onQuestionAdded)
    }
  }
</script>