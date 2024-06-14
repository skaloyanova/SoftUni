function addItem() {
    //get elements
    const ulItemsElement = document.getElementById('items');
    const inputTextElement = document.getElementById('newItemText');

    //create li element with user input + delete button
    const liElement = document.createElement('li');
    liElement.textContent = inputTextElement.value;

    const aElement = document.createElement('a');
    aElement.href = '#';
    aElement.textContent = '[Delete]';

    //Add event listener to aElement
    
    // aElement.addEventListener('click', function () {
    //     aElement.parentNode.remove();
    // })

    aElement.addEventListener('click', function (event) {
        event.currentTarget.parentNode.remove();
    })

    //append elements to DOM
    liElement.append(aElement);
    ulItemsElement.append(liElement);

    //clean up input field
    inputTextElement.value = '';
    inputTextElement.focus();
}