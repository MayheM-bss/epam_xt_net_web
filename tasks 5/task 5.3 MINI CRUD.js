class Service {
  constructor() {
    this.items = new Array();
    this.id = 0;
  }

  add(obj) {
    if (checkParams("", obj)) {
      this.id++;
      obj.id = "id" + this.id;
      this.items.push(obj);
    }
  }

  getById(id) {
    if (checkParams(id)) {
      return this.searchById(id);
    }
  }

  getAll() {
    return this.items;
  }

  deletedById(id) {
    if (checkParams(id)) {
      let temp = this.searchById(id);
      if (temp != null) {
        this.items.splice(this.items.indexOf(temp), 1);
        return temp;
      }
    }
  }

  replaceById(id, obj) {
    if (checkParams(id, obj)) {
      let temp = this.searchById(id);
      if (temp != null) {
        obj.id = id;
        this.items[this.items.indexOf(temp)] = obj;
      }
    }
  }

  updateById(id, obj) {
    if (checkParams(id, obj)) {
      let temp = this.searchById(id);
      if (temp != null) {
        for (let prop in obj) {
          temp[prop] = obj[prop];
        }
      }
    }
  }

  searchById(id) {
    for (let i = 0; i <= this.items.length; i++) {
      if (this.items[i].id == id) {
        return this.items[i];
      }
      return null;
    }
  }

  checkParams(id, obj = {}) {
    return typeof id == "string" && typeof obj == "object";
  }
}
