import MsModal from "../ms-modal"

export default {
  name: 'ms-feedback-question-modal',
  data() {
    return {
      model: {}
    }
  },
  methods: {
    close() {
      let modelResult = {
        title: this.$refs.question.value,
        Answers: [{message: this.$refs.answer.value}]
      }
      this.$http.post('/api/Question/addQuestion', modelResult)
      this.$modals.close(modelResult)
    },
    cancel() {
      this.$modals.dismiss()
    }
  },
  render() {
    return (
      <MsModal>
        <div slot="body" class="s12 m12">
          <div class="bold">Укажите проблему:</div>
          <input ref="question" class="inputTextMainSite" type="text" />
          <div class="bold">Задайте вопрос:</div>
          <textarea ref="answer" class="inputTextMainSite"></textarea>
        </div>
        <div slot="footer" style="display:flex;justify-content: space-between;">
          <button style="padding: 0px 30px;" class="btn btn-defaultMainSite" onClick:prevent={this.cancel}>отмена</button>
          <span style="padding: 0px 30px;" class="btn btn-defaultMainSite" onClick:prevent={this.close}>сохранить</span>
        </div>
      </MsModal>
    )
  },
}
