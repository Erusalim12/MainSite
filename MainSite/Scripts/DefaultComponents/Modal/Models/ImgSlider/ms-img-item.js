export default {
  name: 'ms-img-item',
  props: {
    item: {
      type: Object,
      default: null
    },
    isDisplay: {
      type: Boolean,
      default: true
    },
  },
  data() {
    return {
      visibilityImgBlock: {visibility : 'hidden'}
    }
  },
  computed: {
    getItem() {
      if(this.item == null) {
        return <h4>Загрузка изображения...</h4>
      }
      else {
        let styleImg = { display: (this.isDisplay ? 'inherit': 'none') }
        return (
         <div style={this.visibilityImgBlock}> 
          <img 
            src={this.item.src.replace('/thumbs/', '/')}
            id={this.item.id} 
            onLoad={this.onLoaded.bind(this)}
            style={styleImg}
          />
         </div>
        )
      }
    }
  },
  methods: {
    onLoaded(e) {
      let imgWidth = e.target.width
      let imgHeight = e.target.height
      let scale = imgWidth / imgHeight

      let tempHeight = window.outerHeight * (3 / 4)
      let tempWidth = tempHeight * scale

      if(tempWidth >= window.outerWidth) {
        tempWidth = window.outerWidth * (3 / 4)
        if(imgHeight < window.outerHeight) {
          tempHeight = tempWidth * (imgHeight / imgWidth)
        }
      }

      e.target.width = tempWidth                  
      e.target.height = tempHeight

      this.visibilityImgBlock.visibility = 'inherit'
    }
  },
  render() {
    return this.getItem;
  }
}