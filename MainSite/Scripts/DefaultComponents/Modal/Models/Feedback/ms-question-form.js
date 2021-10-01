export default {
    name: 'ms-question-form',
    props: {
      item: {
        type: Object,
        default: null
      },
    },
    computed: {
      getItem() {
          if(this.item == null) {
            return <span>Загрузка изображения...</span>
          }
          else {
            return <img src={this.item.src.replace('/thumbs/', '/')} id={this.item.id}  />
          }
      }
    },
    mounted () {
    },
    render() {
      return (
        <div style="display: flex;">{this.getItem}</div>
      )
    },
  }