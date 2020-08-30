import { Service } from "./storage.js";

class Note {
  constructor(heading, text) {
    this.heading = heading;
    this.text = text;
  }
}

let storage = new Service();

let changeNoteId;

let notes = document.getElementById("notes");

let buttonAdd = document.getElementById("addNote");
buttonAdd.addEventListener("click", showModalWindow);

let buttonCloseAddForm = document.getElementById("addFormClose");
buttonCloseAddForm.addEventListener("click", showModalWindow);

let buttonCreateAddForm = document.getElementById("create");
buttonCreateAddForm.addEventListener("click", createNote);

let buttonCloseChangeForm = document.getElementById("close");
buttonCloseChangeForm.addEventListener("click", showModalWindow);

let buttonSaveChangeForm = document.getElementById("save");
buttonSaveChangeForm.addEventListener("click", changeNote);

function showModalWindow() {
  switch (event.target.id) {
    case "addNote":
      formDisplay(document.getElementById("addForm"), true);
      break;
    case "create":
    case "addFormClose":
      formDisplay(document.getElementById("addForm"), false);
      clearCreateForm();
      break;
    case "close":
      formDisplay(document.getElementById("changeForm"), false);
      break;
  }
}

function createNote() {
  let heading = document.getElementById("noteHeadCreate").value;
  let text = document.getElementById("noteTextCreate").textContent;
  if (heading === "" && text === "") {
    alert("Невозможно создать пустую заметку");
  } else {
    let note = new Note(heading, text);
    showModalWindow();
    storage.add(note);
    printNote(note);
    let noteId = document.getElementById(note.id);
    noteId.addEventListener("click", openChangeWindow);
  }
}

function changeNote() {
  let heading = document.getElementById("noteHeadChange").value;
  let text = document.getElementById("noteTextChange").textContent;
  if (heading === "" && text === "") {
    alert("Заметка не может быть пустой");
  } else {
    storage.replaceById(changeNoteId, new Note(heading, text));
    let note = document.getElementById(changeNoteId);
    note.querySelector(".noteHead").textContent = heading;
    note.querySelector(".noteText").textContent = text;
    notes.prepend(note);
    formDisplay(document.getElementById("changeForm"), false);
  }
}

function openChangeWindow() {
  if (event.target.id != "delete") {
    changeNoteId = this.id;
    let note = storage.getById(changeNoteId);
    document.getElementById("noteHeadChange").value = note.heading;
    document.getElementById("noteTextChange").textContent = note.text;
    formDisplay(document.getElementById("changeForm"), true);
  }
}

function clearCreateForm() {
  document.getElementById("noteHeadCreate").value = "";
  document.getElementById("noteTextCreate").textContent = "";
}

function printNote(note) {
  let divnote = document.createElement("div");
  divnote.classList.add("note");
  divnote.id = note.id;
  let noteHeading = document.createElement("div");
  noteHeading.classList.add("noteHead");
  noteHeading.innerHTML = note.heading;
  let noteText = document.createElement("p");
  noteText.classList.add("noteText");
  noteText.innerHTML = note.text;
  let buttonDelete = document.createElement("div");
  buttonDelete.innerHTML =
    '<img id="delete" src="img/trash.png" alt="Удалить заметку" />';
  buttonDelete.classList.add("deleteButton");
  divnote.append(noteHeading);
  divnote.append(noteText);
  divnote.append(buttonDelete);
  notes.prepend(divnote);
  let buttonDeleteNote = document.getElementById("delete");
  buttonDeleteNote.addEventListener("click", () => {
    deleteNote(note.id);
  });
}

function deleteNote(id) {
  let choice = confirm("Удалить заметку?");
  if (choice) {
    document.getElementById(id).remove();
    storage.deleteById(id);
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
