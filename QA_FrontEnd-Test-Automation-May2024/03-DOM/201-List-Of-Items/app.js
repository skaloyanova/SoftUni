function addItem() {
    //locate related elements
    const inputElement = document.getElementById('newItemText');
    const ulElement = document.getElementById('items');

    //create new LI element
    const newLiElement = document.createElement('li');
    newLiElement.textContent = inputElement.value;

    //append new li to DOM
    ulElement.append(newLiElement);

    //clear input field
    inputElement.value = '';

    //focus on input
    inputElement.focus();
}