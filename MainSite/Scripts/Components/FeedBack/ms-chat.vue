<template>
  <div class="row" v-if="question">
    <div class="card card-panel">
      <ms-add-answer :questionId="this.getQuestionId" @answer-added="onAnswerAdded" />
      <hr/>
      <div v-if="hasAnswers">
        <div 
          v-for="answer in question.answers" 
          :key="answer.id" 
          class="card card-panel message" 
          v-bind:class="answer.isAdmin ? 'message-admin': ''"
        >
          <div class="message-sender">{{ SenderNameUser(answer.senderName, answer.isAdmin) }}</div>
          <div class="message-body">{{ answer.message }}</div>
          <div class="message-date">{{ RefactDate(answer.date) }}</div>
        </div>
      </div>
    </div>  
  </div>
</template>
 
<script>
import msAddAnswer from './ms-add-answer'
 
export default {
  components: {
    msAddAnswer
  },
  name: 'ms-chat',
  props: {
    questionId : {
      type: String,
      default: ''
    }
  },
  data () {
    return {
      question: null,
    }
  },
  computed: {
    hasAnswers () {
      return this.question.answers.length > 0
    },
    getQuestionId() {
      return this.$route.params.questionId == undefined ? this.questionId: this.$route.params.questionId
    }
  },
  created () {
    this.$http.get(`/api/Question/${this.getQuestionId}`).then(res => {
      this.question = res.data
      this.$questionHub.questionOpened(this.getQuestionId)
    })
    .then(() => {
      this.$questionHub.$on('answer-added', this.onAnswerAdded)
    })
  },
  beforeDestroy () {
    this.$questionHub.questionClosed(this.getQuestionId)
  },
  methods: {
    onAnswerAdded (answer) {
      if (!this.question.answers.find(a => a.id === answer.id)) {
        this.question.answers.unshift(answer)
      }
    },
    SenderNameUser(senderName, isAdmin) {
      return `${isAdmin ? 'Администратор' : 'Пользователь'}: ${senderName}`
    },
    RefactDate(currentDate) {
      let options = {
        day: 'numeric',
        month: 'long',
        year: 'numeric',
      }

      let date = new Date(currentDate);
      let formatDate = date.toLocaleDateString("ru", options).replace('г.','');
      let minutes = date.getMinutes() < 10 ? `0${date.getMinutes()}` : date.getMinutes();
      let formatTime = `${date.getHours()}:${minutes}`;

      return `${formatDate} в ${formatTime}`;
    }
  }
}
</script>

<style lang="scss" scoped>
.message {
  font-size: 14px;
  width:90%;

  &-admin {
    margin-left:auto;
    border: 2px solid #64b5f6;
  }

  &-sender {

  }

  &-body {
    padding: 5px;
  }

  &-date {
    text-align: right;
    font-size: 12px;
  }
}
</style>