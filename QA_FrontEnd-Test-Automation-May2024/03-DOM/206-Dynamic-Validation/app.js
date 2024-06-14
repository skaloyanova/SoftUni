function validate() {
    const emailElement = document.getElementById('email');

    emailElement.addEventListener('change', validateEmail);

    function validateEmail(event) {
        const userInput = event.target.value;
        const pattern = /^[a-z]+@[a-z]+\.[a-z]+/gm;

        if(pattern.test(userInput)) {
            event.target.classList.remove('error');
        } else {
            event.target.classList.add('error');
        }
    }
}