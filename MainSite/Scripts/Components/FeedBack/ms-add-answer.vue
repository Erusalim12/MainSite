<template>
  <div class="add_answer">
    <div class="add_answer-title">Введите сообщение:</div>
    <div class="add_answer-list_btn">
      <textarea class="inputTextMainSite add_answer-message" name="message" v-model="form.message"></textarea>
      <button class="btn btn-defaultMainSite add_answer-btn" @click="onSubmit" >Отправить</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ms-add-answer',
  props: {
    questionId: {
      type: String,
      required: true
    }
  },
  data () {
    return {
      form: {
        message: '',
        questionId: this.questionId
      },
      textareaClientHeight: 0
    }
  },
  methods: {
    onSubmit (evt) {
      this.$http.post(`api/question/addAnswer`, this.form)
      .then(res => {
        this.form.message = ''
        document.querySelector('textarea').style.height = '2.5rem';
        this.$emit('answer-added', res.data)
      })
      .catch(error => {
        this.form.message = ''
        M.toast({html: error})
      });
    }
  },
  mounted() {
    this.textareaClientHeight = document.querySelector('textarea').clientHeight

    document.querySelector('textarea').addEventListener('input', (e) => {
      e.target.style.height = 'auto'
      e.target.style.height = (e.target.scrollHeight + 2) + "px"
    });
 }
}
</script>

<style lang="scss" scoped>
.btn-defaultMainSite.danger {
  border-color: red;
  color:red;
  &:hover {
    background-color: red;
    color:white;
  }
}
.add_answer {  
  &-message {
    height: 2.5rem;
    flex-basis: 50%;
  }

  &-title {
    margin: 5px;
  }

  &-btn {
    margin-left: 5px;
  }

  &-list_btn {
    display:flex;
    align-items:end;
  }
}
</style>