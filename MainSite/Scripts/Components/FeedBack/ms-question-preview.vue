<template>
  <div class="col m4 l4 s12 preview">
    <router-link :to="{name: 'adminChat', params: {questionId: this.question.id} }">
      <div class="card-panel">
          <span 
            v-if="changeAnswerAdded" 
            class="badge badge-success"
          >
            {{ question.answerCount }}
          </span>
          <p>{{ question.customerId }}</p>
          <a style="text-align:right;display:block;" href="#">
            Перейти к диалогу
          </a>
      </div>
    </router-link>
  </div>
</template>
 
<script>
 
export default {
  name: 'ms-question-preview',
  props: {
    question: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      prevCount: 0,
      changeAnswerAdded: false
    }
  },
  methods: {
    onAnswerCountChanged({ questionId, answerCount }) {
        if(this.question.id !== questionId) return
        this.changeAnswerAdded = true
        Object.assign(this.question, { answerCount: answerCount - this.prevCount })
    }
  },
  created() {
      this.$questionHub.$on('answer-count-changed', this.onAnswerCountChanged)
      this.$questionHub.questionOpened(this.question.id)
      this.prevCount = this.question.answerCount;
  },
  beforeDestroy() {
    this.$questionHub.questionClosed(this.question.id)
  }
}
</script>

<style lang="scss" scoped>
.preview {
  .card-panel {
    cursor: pointer;
    margin-left: -0.75rem;
    position: relative;
    .badge {
      position: absolute;
      right: 5px;
      top: 5px;
      border: 1px solid black;
      border-radius: 20px;
    }
  }
}
</style>