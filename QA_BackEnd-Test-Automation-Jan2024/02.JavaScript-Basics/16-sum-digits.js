function sum(number) {
    'use strict'
    //Write a function, which will be given a single number. Your task is to find the sum of its digits.

    let sum = 0;

    while (number > 0) {
        let digit = number % 10;
        number = Math.floor(number / 10);
        sum += digit;
    }
    console.log(sum);
}

sum(245678);
sum(97561);
sum(543);