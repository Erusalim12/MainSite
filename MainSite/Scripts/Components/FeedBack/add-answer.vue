<template>
  <div id="addAnswerModal" ref="addAnswerModal" style="display:flex">
    <p>Введите сообщение:</p>
    <textarea class="inputTextMainSite" name="message" v-model="this.form.title"></textarea>
    <button class="btn btn-defaultMainSite" type="submit" >Отправить сообщение</button>
    <button class="btn btn-defaultMainSite" @click="">Вернуться назад</button>
    </b-form>
  </div>
</template>

<script>
export default {
  props: {
    propsQuestionId: {
      type: String,
      required: true
    }
  },
  data () {
    return {
      form: {
        title: '',
        questionId: this.propsQuestionId
      }
    }
  },
  methods: {
    onSubmit (evt) {
      this.$http.post(`api/question/${this.propsQuestionId}/answer`, this.form).then(res => {
        //this.$emit('answer-added', res.data)
      })
    },
    onCancel (evt) {
      this.$router.push({name: 'feedback'})
    },
  }
}
</script>