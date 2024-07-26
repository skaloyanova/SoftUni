window.addEventListener('load', solve);

function solve() {
    //Locate elements
    const timeElement = document.getElementById('time');
    const dateElement = document.getElementById('date');
    const placeElement = document.getElementById('place');
    const eventElement = document.getElementById('event-name');
    const emailElement = document.getElementById('email');
    const addButtonElement = document.getElementById('add-btn');

    const ulLastCheckElement = document.getElementById('check-list');
    const ulUpcomingElement = document.getElementById('upcoming-list');
    const ulFinishedElement = document.getElementById('finished-list');
    const clearButton = document.getElementById('clear');

    addButtonElement.addEventListener('click', onAdd);

    /*********************
     * ADD functionality *
     *********************/
    function onAdd(e) {
        e.preventDefault();

        //validate input data
        if (timeElement.value == '' ||
            dateElement.value == '' ||
            placeElement.value == '' ||
            eventElement.value == '' ||
            emailElement.value == ''
        ) return;

        //create HTML structure
        const liElement = document.createElement('li');
        liElement.classList.add('event-content');

        const articleElement = document.createElement('article');

        const timeAndDateParaElement = document.createElement('p');
        const placeParaElement = document.createElement('p');
        const eventParaElement = document.createElement('p');
        const emailParaElement = document.createElement('p');

        timeAndDateParaElement.textContent = `Begins: ${dateElement.value} at: ${timeElement.value}`;
        placeParaElement.textContent = `In: ${placeElement.value}`;
        eventParaElement.textContent = `Event: ${eventElement.value}`;
        emailParaElement.textContent = `Contact: ${emailElement.value}`;

        const editButton = document.createElement('button');
        editButton.classList.add('.edit-btn');
        editButton.textContent = 'Edit';

        const continueButton = document.createElement('button');
        continueButton.classList.add('.continue-btn');
        continueButton.textContent = 'Continue';

        articleElement.append(timeAndDateParaElement, placeParaElement, eventParaElement, emailParaElement);
        liElement.append(articleElement, editButton, continueButton);
        ulLastCheckElement.append(liElement);

        //keep input values before removal
        let timeValue = timeElement.value;
        let dateValue = dateElement.value;
        let placeValue = placeElement.value;
        let eventValue = eventElement.value;
        let emailValue = emailElement.value;

        //clear input fields
        timeElement.value = '';
        dateElement.value = '';
        placeElement.value = '';
        eventElement.value = '';
        emailElement.value = '';

        addButtonElement.disabled = true;
    }
}




