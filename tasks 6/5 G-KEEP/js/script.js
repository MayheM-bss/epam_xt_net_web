import { Service } from "./storage.js";

class Note {
  constructor(heading, text) {
    this.heading = heading;
    this.text = text;
  }
}

let storage = new Service();

let changeNoteId;

let addButton = document.getElementById("addNote");
addButton.addEventListener("click", openCreateWindow);
let closeAddFormButton = document.getElementById("addFormClose");
closeAddFormButton.addEventListener("click", closeCreateWindow);
let createAddFormButton = document.getElementById("create");
createAddFormButton.addEventListener("click", createNote);
let closeChangeFormButton = document.getElementById("close");
closeChangeFormButton.addEventListener("click", closeChangeWindow);
let saveChangeFormButton = document.getElementById("save");
saveChangeFormButton.addEventListener("click", changeNote);

function openCreateWindow() {
  let elem = document.getElementById("addForm");
  formDisplay(elem, true);
}

function closeCreateWindow() {
  let elem = document.getElementById("addForm");
  formDisplay(elem, false);
  clearCreateForm();
}

function closeChangeWindow() {
  let elem = document.getElementById("changeForm");
  formDisplay(elem, false);
}

function createNote() {
  let headingField = document.getElementById("noteNameCreate");
  let heading = headingField.value;
  let textField = document.getElementById("noteTextCreate");
  let text = textField.value;
  if (heading === "" && text === "") {
    alert("Невозможно создать пустую заметку");
  } else {
    let note = new Note(heading, text);
    closeCreateWindow();
    storage.add(note);
    printNote(note);
    let noteId = document.getElementById(note.id);
    noteId.addEventListener("click", openChangeWindow);
  }
}

function changeNote() {
  let heading = document.getElementById("noteNameChange").value;
  let text = document.getElementById("noteTextChange").value;
  if (heading === "" && text === "") {
    alert("Заметка не может быть пустой");
  } else {
    storage.replaceById(changeNoteId, new Note(heading, text));
    let note = document.getElementById(changeNoteId);
    note.querySelector(".noteHead").textContent = heading;
    note.querySelector(".noteText").textContent = text;
    notes.prepend(note);
    let elem = document.getElementById("changeForm");
    formDisplay(elem, false);
  }
}

function openChangeWindow() {
  if (event.target.id != "delete") {
    changeNoteId = this.id;
    let note = storage.getById(changeNoteId);
    document.getElementById("noteNameChange").value = note.heading;
    document.getElementById("noteTextChange").value = note.text;
    let elem = document.getElementById("changeForm");
    formDisplay(elem, true);
  }
}

function clearCreateForm() {
  document.getElementById("noteNameCreate").value = "";
  document.getElementById("noteTextCreate").value = "";
}

function printNote(note) {
  let notes = document.getElementById("notes");
  let divnote = document.createElement("div");
  divnote.classList.add("note");
  divnote.id = note.id;
  let noteHeading = document.createElement("div");
  noteHeading.classList.add("noteHead");
  noteHeading.innerHTML = note.heading;
  let noteText = document.createElement("p");
  noteText.classList.add("noteText");
  noteText.innerHTML = note.text;
  let deleteButton = document.createElement("div");
  deleteButton.innerHTML =
    '<img id="delete" src="img/trash.png" alt="Удалить заметку" />';
  deleteButton.classList.add("deleteButton");
  divnote.append(noteHeading);
  divnote.append(noteText);
  divnote.append(deleteButton);
  notes.prepend(divnote);
  let deleteNote = document.getElementById("delete");
  deleteNote.addEventListener("click", () => {
    deleteNoteFunction(note.id);
  });
}

function deleteNoteFunction(id) {
  let choice = confirm("Удалить заметку?");
  if (choice) {
    document.getElementById(id).remove();
    storage.deleteById(id);
    console.log(storage);
  }
}

function formDisplay(elem, on) {
  if (on) {
    elem.classList.remove("disable");
    showBlocker();
  } else {
    elem.classList.add("disable");
    hideBlocker();
  }
}

function showBlocker() {
  let blocker = document.createElement("div");
  blocker.id = "blocker";
  document.body.append(blocker);
}

function hideBlocker() {
  document.getElementById("blocker").remove();
}
