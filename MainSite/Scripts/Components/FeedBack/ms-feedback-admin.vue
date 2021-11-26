<template>
  <div class="row">
    <template v-if="availabilityQuestionUsers">
      <h5>Список обращений от пользователей</h5>
      <ms-question-preview
        v-for="(value, name) in questionUsers"
        :key="name"
        :question="questionUsers[name]"
        :title="name"
      />
    </template>
    <template v-else>
      <h5>Список проблем и пожеланий от пользователей отсутствует</h5>
    </template>
  </div>
</template>

<script>
import axios from "axios";

import msQuestionPreview from "../FeedBack/ms-question-preview.vue";

export default {
  name: "ms-feedback-admin",
  components: {
    msQuestionPreview,
  },
  data() {
    return {
      questionUsers: {},
      availabilityQuestionUsers: false,
    };
  },
  methods: {
    onQuestionAdded(question) {
      if (!this.questionUsers.find((a) => a.id === question.id)) {
        this.questionUsers = [
          Object.assign(question, { answerCount: question.answers.length }),
          ...this.questionUsers,
        ];
      }
    },
    generateQuestionUsers(list) {
      return list.reduce((previousValue, item) => {
        let obj = {
          answerCount: item.answerCount,
          endDate: item.endDate,
          id: item.id,
        };

        if (!previousValue[item.customerId])
          previousValue[item.customerId] = { current: {}, completed: [] };

        if (!obj.endDate) {
          previousValue[item.customerId].current = item;
        } else {
          previousValue[item.customerId].completed.push(item);
        }

        return previousValue;
      }, this.questionUsers);
    },
  },
  created() {
    axios.get("/api/Question/question").then((res) => {
      let questions = res.data;

      this.questionUsers = this.generateQuestionUsers(questions);

      if (Object.keys(this.questionUsers).length > 0)
        this.availabilityQuestionUsers = true;
    });
    this.$questionHub.$on("question-added", this.onQuestionAdded);
  },
};
</script>
