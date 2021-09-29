import MsModal from "../ms-modal"
import '../styles/imageShow.scss'
import {ImageGlobalService} from '../../../Services/ImageModalService'
import MsImageItem from '../Models/ImgSlider/ms-img-item'
import CloseIcon from "../close-icon"

export default {
  name: 'ms-image-modal',
  data() {
    return {
      imgList: [],
      currentIndex: 0
    }
  },
  computed: {
    getImgList() {
      if(this.imgList) {
        return <MsImageItem item={this.imgList[this.currentIndex]}></MsImageItem>
      }

      return <div>Загрузка...</div>
    },
    showPrevArrow() {
      return this.getClassArrow(
        () => this.currentIndex == 0,
        'bodyImage__prevDivBlock'
      )
    },
    showNextArrow() {
      return this.getClassArrow(
        () => this.currentIndex == this.imgList.length - 1,
        'bodyImage__nextDivBlock'
      )
    },
  },
  methods: {
    incrementIndex() {
      if(this.currentIndex < this.imgList.length - 1) {
        this.currentIndex++
      }
    },
    decrementIndex() {
      if(this.currentIndex > 0) {
        this.currentIndex--
      }
    },
    getClassArrow(callback ,prevClass) {
      return`${prevClass} ${(callback(prevClass) ? prevClass + '_desactive': '')}`;
    }
  },
  created () {
    this.imgList = ImageGlobalService.getCurrentImageCalendarService().getData()
  },
  beforeDestroy () {
    ImageGlobalService.destroy()
  },
  render() {
    return (
      <MsModal>
        <div slot="body">
          <div class="bodyImage">
            {this.getImgList}
            <div 
              class={this.showNextArrow}
              onClick={this.incrementIndex}>
                <div  class="arrow arrow-right"></div>
            </div>
            <div 
              class={this.showPrevArrow}
              onClick={this.decrementIndex}>
                <div class="arrow arrow-left"></div>
            </div>            
            <div 
              class="vu-modal__close-btn bodyImage__close-btn"
              onClick={() => { this.$modals.dismiss()}}>
                <CloseIcon />
            </div>
          </div>
        </div>
      </MsModal>
    )
  },
}