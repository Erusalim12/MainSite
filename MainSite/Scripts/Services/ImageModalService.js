class GlobalService {
  constructor() {
    if (this.instance == undefined) {
      this.instance = this;
    }

    return this.instance;
  }

  getCurrentImageCalendarService() {
    return this.instance;
  }

  setCurrentImageCalendarService(service) {
    this.instance = service;
  }

  destroy() {
    this.instance = undefined;
  }
}

export const ImageGlobalService = new GlobalService();

export class ImageCalendarService {
  constructor() {
    this.data = [];
    this.currentItemId = undefined;
    this.selectComponentService = undefined;
  }

  setData(data) {
    this.data = data;
  }

  addItem(item) {
    this.data.push(item);
  }

  getData() {
    return !this.data ? [] : this.data;
  }

  setCurrentItemId(itemId) {
    this.currentItemId = itemId;
  }

  getCurrentIndex() {
    return this.data.length
      ? this.data.findIndex((el) => el.id === this.currentItemId)
      : 0;
  }
}
