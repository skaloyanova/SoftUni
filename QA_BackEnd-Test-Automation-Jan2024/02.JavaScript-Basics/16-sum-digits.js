function sum(number) {
    'use strict';
    //Write a function, which will be given a single number. Your task is to find the sum of its digits.

    let sum = 0;

    while (number > 0) {
        let digit = number % 10;
        number = Math.floor(number / 10);
        sum += digit;
    }
    console.log(sum);
}

function sum2(number) {
    'use strict';

    const numAsString = number.toString();
    let sum = 0;

    for (const char of numAsString) {
        const charToNumber = parseInt(char);
        sum += charToNumber;

    }
    console.log(sum);
}

sum(245678);
sum2(245678);
sum(97561);
sum2(97561);
sum(543);
sum2(543);