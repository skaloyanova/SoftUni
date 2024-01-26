function sameDigits(num) {
    'use strict';

    let numAstext = num.toString();
    const firstDigit = parseInt(numAstext.charAt(0));
    let sum = 0;
    let isSameDigit = true;

    for (let i = 0; i < numAstext.length; i++) {
        let digit = parseInt(numAstext.charAt(i));
        sum += digit;

        if(digit != firstDigit) {
            isSameDigit = false;
        }
    }

    console.log(isSameDigit);
    console.log(sum);
}

sameDigits(2222222);
sameDigits(1234);