function oddAndEvenSum(number) {
    'use strict';

    let oddSum = 0;
    let evenSum = 0;

    while(number > 0) {
        const digit = number % 10;
        number = Math.floor(number / 10);

        if(digit % 2 === 0) {
            evenSum += digit;
        } else {
            oddSum += digit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddAndEvenSum(1000435);             //Odd sum = 9, Even sum = 4
oddAndEvenSum(3495892137259234);    //Odd sum = 54, Even sum = 22