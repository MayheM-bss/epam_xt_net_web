const Service = require("./task 5.3 MINI CRUD");

var storage = new Service();

storage.add({
  a: 123,
});
storage.add({
  b: 645,
});

console.log(storage.getById("id2"));
console.log(storage.getAll());
storage.replaceById("id2", {
  hf: 999,
});
storage.updateById("id1", {
  qwe: 7456,
});
console.log(storage);
console.log(storage.deletedById("id1"));
console.log(storage);
