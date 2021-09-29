import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export default{
  install(Vue) {
    let questionHub = new Vue()
    questionHub.questionOpened = (userId, isAdmin) => {
      return startedPromise
        .then(() => connection.invoke('JoinQuestionGroup', userId, isAdmin))
        .catch(console.error)
    }
    questionHub.questionClosed = (userId) => {
      return startedPromise
        .then(() => connection.invoke('LeaveQuestionGroup', userId))
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