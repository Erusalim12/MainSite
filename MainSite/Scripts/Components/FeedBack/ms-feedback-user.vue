<template>
  <div>
    <div
      v-if="Object.keys(question).length == 0"
      style="display: flex; align-items: center; margin: 0.5rem 0 1rem 0"
    >
      <button
        @click="openAddQuestionModal"
        class="btn btn-defaultMainSite"
        style="margin-left: auto"
      >
        Указать проблему
      </button>
    </div>
    <div>
      <ms-chat
        v-if="!(Object.keys(question).length == 0)"
        :questionId="question.id"
      />
    </div>
  </div>
</template>

<script>
import axios from "axios";

import msChat from "../FeedBack/ms-chat";
import feedBackQuestionModal from "../../DefaultComponents/Modal/templates/ms-feedback-question-modal.js";

export default {
  name: "ms-feedback-user",
  components: {
    msChat,
  },
  data() {
    return {
      question: {},
    };
  },
  methods: {
    openAddQuestionModal() {
      this.$modals.open({
        component: feedBackQuestionModal,
        onClose: (newQuestion) => {
          this.question = newQuestion;
        },
      });
    },
    onQuestionDeleted() {
      this.question = {};
    },
  },
  created() {
    axios.get("/api/Question/question").then((res) => {
      let questions = res.data;
      if (questions.length) this.question = questions[questions.length - 1];
    });
    this.$questionHub.$on("question-deleted", this.onQuestionDeleted);
  },
};
</script>
