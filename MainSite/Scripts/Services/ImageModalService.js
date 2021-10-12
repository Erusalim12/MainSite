class GlobalService {

  constructor() {
    if(this.instance == undefined) {
      this.instance = this;
    }

    return this.instance;
  }

  getCurrentImageCalendarService() {
    return this.instance
  }

  setCurrentImageCalendarService(service) {
    this.instance = service
  }

  destroy() {
    this.instance = undefined
  }

}

export const ImageGlobalService =  new GlobalService();


export class ImageCalendarService {
  constructor() {
    this.data = []
    this.currentItemId = undefined
    this.selectComponentService = undefined
  }

  setData(data) {
    this.data = data
  }

  addItem(item) {
    this.data.push(item)
  }

  getData() {
    if(!this.data) return []

    if(this.currentItemId) {
      return this.data.sort((x,y) => x.id == this.currentItemId ? -1 : y.id == this.currentItemId ? 1 : 0)
    }

    return this.data
  }

  setCurrentItemId(itemId) {
    this.currentItemId = itemId
  }

}