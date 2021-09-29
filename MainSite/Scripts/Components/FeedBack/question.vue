<template>
  <article class="container" v-if="question">
    <header class="row align-items-center">
      <question-score :question="question" class="col-1" />
      <h3 class="col-11">{{ question.title }}</h3>
    </header>
    <p class="row">
      <vue-markdown class="offset-1 col-11">{{ question.body }}</vue-markdown>
    </p>
    <ul class="list-unstyled row" v-if="hasAnswers">
      <li v-for="answer in question.answers" :key="answer.id" class="offset-1 col-11 border-top py-2">
        <vue-markdown>{{ answer.body }}</vue-markdown>
      </li>
    </ul>
      <button class="btn btn-primary float-right" v-b-modal.addAnswerModal><i class="fas fa-edit"/> Post your Answer</button>
      <button class="btn btn-link float-right" @click="onReturnFeedBack">Back to list</button>
    <add-answer-modal :question-id="this.questionId" @answer-added="onAnswerAdded"/>
  </article>
</template>
 
<script>
import VueMarkdown from 'vue-markdown'
import QuestionScore from './question-score'
import AddAnswerModal from './add-answer-modal'
 
export default {
  components: {
    VueMarkdown,
    QuestionScore,
    AddAnswerModal
  },
  data () {
    return {
      question: null,
      answers: [],
      questionId: this.$route.params.id
    }
  },
  computed: {
    hasAnswers () {
      return this.question.answers.length > 0
    }
  },
  created () {
    this.$http.get(`/api/Question/${this.questionId}`).then(res => {
      this.question = res.data
      //console.log(this.$questionHub)
      //return this.$questionHub.questionOpened(this.questionId)
    })
  },
  beforeDestroy () {
    // Notify the server we stopped watching the question
    this.$questionHub.questionClosed(this.questionId)
  },
  methods: {
    onReturnFeedBack () {
      this.$router.push({name: 'feedback'})
    }, 
    onAnswerAdded (answer) {
      if (!this.question.answers.find(a => a.id === answer.id)) {
        this.question.answers.push(answer)
      }
    }
  }
}
</script>