window.addEventListener("load", solve);

function solve() {
    //Locate elements
    const numTicketsElement = document.getElementById('num-tickets');
    const seatPrefElement = document.getElementById('seating-preference');
    const fullNameElement = document.getElementById('full-name');
    const emailElement = document.getElementById('email');
    const phoneElement = document.getElementById('phone-number');

    const purchaseButton = document.getElementById('purchase-btn');

    const ulTicketPreview = document.getElementById('ticket-preview');
    const ulTicketPurchase = document.getElementById('ticket-purchase');

    //add event listener for Purchase button
    purchaseButton.addEventListener('click', onPurchase);

    /**************************
     * PURCHASE functionality *
     **************************/
    function onPurchase(e) {
        e.preventDefault();

        //Validate input
        if (numTicketsElement.value == '' || seatPrefElement.value == '' || fullNameElement.value == '' || emailElement.value == '' || phoneElement.value == '') return;

        //build HTML structure for Ticket Preview list and add data in it
        const liElement = document.createElement('li');
        liElement.classList.add('ticket-purchase');

        const articleElement = document.createElement('article');

        const pNumTicketsElement = document.createElement('p');
        const pSeatPrefElement = document.createElement('p');
        const pFullNameElement = document.createElement('p');
        const pEmailElement = document.createElement('p');
        const pPhoneElement = document.createElement('p');

        pNumTicketsElement.textContent = 'Count: ' + numTicketsElement.value;
        pSeatPrefElement.textContent = 'Preference: ' + seatPrefElement.value;
        pFullNameElement.textContent = 'To: ' + fullNameElement.value;
        pEmailElement.textContent = 'Email: ' + emailElement.value;
        pPhoneElement.textContent = 'Phone number: ' + phoneElement.value;

        const divElement = document.createElement('div');
        divElement.classList.add('btn-container');

        const editButton = document.createElement('button');
        editButton.classList.add('edit-btn');
        editButton.textContent = 'Edit';

        const nextButton = document.createElement('button');
        nextButton.classList.add('next-btn');
        nextButton.textContent = 'Next';

        divElement.append(editButton, nextButton);
        articleElement.append(pNumTicketsElement, pSeatPrefElement, pFullNameElement, pEmailElement, pPhoneElement);
        liElement.append(articleElement, divElement);
        ulTicketPreview.append(liElement);

        //keep values from input fields before clearing them
        let numTicketsValue = numTicketsElement.value;
        let seatPrefValue = seatPrefElement.value;
        let fullNameValue = fullNameElement.value;
        let emailValue = emailElement.value;
        let phoneValue = phoneElement.value;

        //clear input fields
        numTicketsElement.value = '';
        seatPrefElement.value = '';
        fullNameElement.value = '';
        emailElement.value = '';
        phoneElement.value = '';

        //disable Purchase Button
        purchaseButton.disabled = true;

        //add event listener for Edit and Next buttons
        editButton.addEventListener('click', onEdit);
        nextButton.addEventListener('click', onNext);

        /**************************
         * EDIT functionality *
         **************************/
        function onEdit() {
            numTicketsElement.value = numTicketsValue;
            seatPrefElement.value = seatPrefValue;
            fullNameElement.value = fullNameValue;
            emailElement.value = emailValue;
            phoneElement.value = phoneValue;

            purchaseButton.disabled = false;

            //revove LI from Ticket Preview list
            ulTicketPreview.removeChild(liElement);
        }

        /**************************
         * NEXT functionality *
         **************************/
        function onNext() {
            //move LI element from Ticket Preview to Ticket Purchase list
            ulTicketPurchase.appendChild(liElement);

            //remove Edit and Next buttons
            divElement.removeChild(editButton);
            divElement.removeChild(nextButton);

            //add Buy button
            const buyButton = document.createElement('button');
            buyButton.classList.add('buy-btn');
            buyButton.textContent = 'Buy';

            //Условието на задачата беше променено в последствие по време на изпита и според новото условие, бутона трябва да се добави в <article>, но аз го оставям както беше преди и както е при Edit и Next бутони, т.е. в div container с клас .btn-container
            divElement.appendChild(buyButton);

            //add event listener for Buy button
            buyButton.addEventListener('click', onBuy);


            /*********************
             * BUY functionality *
             *********************/
            function onBuy() {
                //revove LI from Ticket Purchase list
                ulTicketPurchase.removeChild(liElement);

                //create h2 and Back button
                const h2Element = document.createElement('h2');
                h2Element.textContent = 'Thank you for your purchase!';

                const backButton = document.createElement('button');
                backButton.classList.add('back-btn');
                backButton.textContent = 'Back';

                //append h2 and Back button to div with class .bottom-content
                const divBottomElement = document.querySelector('.bottom-content');
                divBottomElement.append(h2Element, backButton);

                //add event listener for Buy button
                backButton.addEventListener('click', onBack);


                /**********************
                 * BACK functionality *
                 **********************/
                function onBack() {
                    window.location.reload();
                }
            }
        }
    }
}