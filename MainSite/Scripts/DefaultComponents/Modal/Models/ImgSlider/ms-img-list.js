import MsImageItem from './ms-img-item'

export default {
  name: 'ms-img-list',
  props: {
    array: {
      type: Array,
      default: []
    },
    currentIndex: {
        type: Number,
        default: 0
    }
  },
  render() {
    return (
      <div>
        {
          this.array.map((el, index) => <MsImageItem item={el} isDisplay={this.currentIndex == index} />)
        }
      </div>
    )
  },
}