export default {
  name: 'ms-img-item',
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
          return <img src={this.item.src} id={this.item.id}  />
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