function addAndSubtract(num1, num2, num3) {
    'use strict';

    function add(a, b) {
        return a + b;
    }

    // function subtract(a, b) {
    //     return a - b;
    // }

    const subtract = (a, b) => a - b;

    console.log(subtract(add(num1, num2), num3));
}

addAndSubtract(23, 6, 10);    //19
addAndSubtract(1, 17, 30);    //-12
addAndSubtract(42, 58, 100);  //0