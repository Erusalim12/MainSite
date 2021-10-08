import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export default{
  install(Vue) {
    let questionHub = new Vue()
    questionHub.questionOpened = questionId => {
      return startedPromise
        .then(() => connection.invoke('CreateQuestionGroup', questionId))
        .catch(console.error)
    }
    questionHub.questionClosed = questionId => {
      return startedPromise
        .then(() => connection.invoke('RemoveQuestionGroup', questionId))
        .catch(console.error)
    }
    questionHub.connetionAdminOpened = () => {
      return startedPromise
        .then(() => connection.invoke('CreateAdminGroup'))
        .catch(console.error)
    }
    questionHub.connetionAdminClosed = () => {
      return startedPromise
        .then(() => connection.invoke('RemoveAdminGroup'))
        .catch(console.error)
    }
  
    Vue.prototype.$questionHub = questionHub

    const host = `${window.location.protocol + "//"}${window.location.host}`
    const connection = new HubConnectionBuilder()
      .withUrl(`${host}/question-hub`)
      .configureLogging(LogLevel.Information)
      .build()

    connection.on('QuestionScoreChange', (questionId, score) => {
      questionHub.$emit('score-changed', { questionId, score })
    })
    connection.on('AnswerCountChange', (questionId, answerCount) => {
      questionHub.$emit('answer-count-changed', { questionId, answerCount })
    })
    connection.on('AnswerAdded', answer => {
      questionHub.$emit('answer-added', answer)
    })
    connection.on('AddQuestionChange', question => {
      questionHub.$emit('question-added', question)
    })
    connection.on('DeleteQuestionChange', () => {
      questionHub.$emit('question-deleted')
    })

    let startedPromise = null
    function start () {
      startedPromise = connection.start().catch(err => {
        console.error('Failed to connect with hub', err)
        return new Promise((resolve, reject) => 
          setTimeout(() => start().then(resolve).catch(reject), 5000))
      })
      return startedPromise
    }

    start()

    connection.onclose(() => start())   
       
  }
}