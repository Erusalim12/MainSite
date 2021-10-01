<template>
  <div class="row" v-if="question">
    <header class="row align-items-center">
      <!--<question-score :question="question" class="col-1" />-->
      <h3 class="col-11">{{ question.title }}</h3>
    </header>
    <add-answer :propsQuestionId="question.id"></add-answer>
    <ul class="list-unstyled row" v-if="hasAnswers">
      <li v-for="answer in question.answers" :key="answer.id" class="offset-1 col-11 border-top py-2">
        <vue-markdown>{{ answer.body }}</vue-markdown>
      </li>
    </ul>
    <!--<add-answer-modal :question-id="this.questionId" @answer-added="onAnswerAdded"/>-->
  </div>
</template>
 
<script>
import VueMarkdown from 'vue-markdown'
import QuestionScore from './question-score'
import AddAnswer from './add-answer'
 
export default {
  components: {
    VueMarkdown,
    QuestionScore,
    AddAnswer
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