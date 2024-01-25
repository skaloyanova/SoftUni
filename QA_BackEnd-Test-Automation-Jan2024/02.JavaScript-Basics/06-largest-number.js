function largestNumber(num1, num2, num3) {
    'use strict'
    let max = num1;
    if (num2 >= num1 && num2 >= num3) {
        max = num2;
    }
    else if (num3 >= num1 && num3 >= num2) {
        max = num3;
    }
    console.log(`The largest number is ${max}.`)
}

largestNumber(5, -3, 16)
largestNumber(-3, -5, -22.5)