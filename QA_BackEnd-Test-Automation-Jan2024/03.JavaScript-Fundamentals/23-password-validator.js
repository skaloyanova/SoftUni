function validatePassword(password) {
    'use strict';
    //The length should be 6 - 10 characters (inclusive)
    //It should consist only of letters and digits
    //It should have at least 2 digits 

    const validLength = (pass) => pass.length >= 6 && pass.length <= 10;
   
    const validLetterDigitOnly = (pass) => pass.match(/[^a-zA-Z0-9]+/g) == null;    //match anything that is not a letter or digit

    const validAtLeastTwoDigits = (pass) => {
        const matches = pass.match(/[0-9]/g);            //match only digits
        return (matches != null) && matches.length >= 2;
    };

    if (validLength(password) && validLetterDigitOnly(password) && validAtLeastTwoDigits(password)) {
        console.log('Password is valid');
    } else {
        if (!validLength(password)) {
            console.log('Password must be between 6 and 10 characters');
        }
        if (!validLetterDigitOnly(password)) {
            console.log('Password must consist only of letters and digits');
        }
        if (!validAtLeastTwoDigits(password)) {
            console.log('Password must have at least 2 digits');
        }
    }
}

console.log('>> example 1');
validatePassword('logIn');
console.log('>> example 2');
validatePassword('MyPass123');
console.log('>> example 3');
validatePassword('Pa$s$s');