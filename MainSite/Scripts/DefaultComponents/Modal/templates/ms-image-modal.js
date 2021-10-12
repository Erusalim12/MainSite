import MsModal from "../ms-modal"
import '../styles/imageShow.scss'
import {ImageGlobalService} from '../../../Services/ImageModalService'
import MsImageList from '../Models/ImgSlider/ms-img-list'
import CloseIcon from "../close-icon"

export default {
  name: 'ms-image-modal',
  data() {
    return {
      imgList: [],
      currentIndex: 0,
      displayArrowImgList: {display: 'none'}
    }
  },
  computed: {
    getImgList() {
      if(this.imgList !== undefined && this.imgList[this.currentIndex] !== undefined) {
        this.displayArrowImgList = {}
        return <MsImageList array={this.imgList} currentIndex={this.currentIndex} />
      }

      this.displayArrowImgList = {display: 'none'}
      return <h4>Загрузка изображений...</h4>
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
      return`${prevClass} ${(callback(prevClass) ? prevClass + '_desactive': '')}`
    },
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
          <div ref="bodyImage" class="bodyImage" slot="body">
            {this.getImgList}
            <div 
              class={this.showNextArrow}
              onClick={this.incrementIndex}
              style={this.displayArrowImgList}
            >
              <div class="arrow arrow-right"></div>
            </div>
            <div 
              class={this.showPrevArrow}
              onClick={this.decrementIndex}
              style={this.displayArrowImgList}
            >
              <div class="arrow arrow-left"></div>
            </div>            
            <div 
              class="vu-modal__close-btn bodyImage__close-btn"
              onClick={() => { this.$modals.dismiss()}}>
              <CloseIcon />
            </div>
          </div>
      </MsModal>
    )
  },
}