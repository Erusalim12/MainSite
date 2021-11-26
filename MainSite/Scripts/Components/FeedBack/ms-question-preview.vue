<template>
  <div class="col m4 l4 s12 preview">
    <div class="card-panel">
      <span v-if="changeAnswerAdded" class="badge badge-success">
        {{ question.answerCount }}
      </span>
      <p>{{ title }}</p>
      <div>
        <span>Перейти в</span>
        <router-link
          v-if="Object.keys(question.current).length > 0"
          :to="{
            name: 'adminChat',
            params: {
              questionId: this.question.current.id,
            },
          }"
        >
          диалог,
        </router-link>
        <a
          @click.prevent
          v-tooltip="{
            ref: 'tooltipRef',
            class: 'tooltip-custom',
          }"
          style="cursor: pointer"
        >
          историю сообщений
        </a>
        <div ref="tooltipRef">
          <div>
            Количество закрытых сообщений: {{ question.completed.length }}
          </div>
          <router-link
            v-for="item in question.completed"
            :key="item.id"
            :to="{
              name: 'adminChat',
              params: {
                questionId: item.id,
                questionEndDate: new Date(item.endDate).toLocaleDateString(),
              },
            }"
          >
            Диалог от {{ new Date(item.endDate).toLocaleDateString() }}
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ms-question-preview",
  props: {
    question: {
      type: Object,
      required: true,
    },
    title: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      prevCount: 0,
      changeAnswerAdded: false,
    };
  },
  methods: {
    onAnswerCountChanged({ questionId, answerCount }) {
      if (this.question.id !== questionId) return;
      this.changeAnswerAdded = true;
      Object.assign(this.question, {
        answerCount: answerCount - this.prevCount,
      });
    },
  },
  created() {
    this.$questionHub.$on("answer-count-changed", this.onAnswerCountChanged);
    this.$questionHub.questionOpened(this.question.id);

    this.prevCount = this.question.answerCount;
  },
  beforeDestroy() {
    this.$questionHub.questionClosed(this.question.id);
  },
};
</script>

<style lang="scss">
.preview {
  .card-panel {
    font-size: 12px;
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

.vue-tooltip.tooltip-custom {
  background-color: white;
  border-radius: 8px;
  font-size: 12px;
  color: #9e9e9e;
  .tooltip-arrow {
    border-color: white !important;
  }

  .tooltip-content {
    a {
      display: block !important;
      padding: 5px 0px 5px 0px;
    }
  }
}
</style>
