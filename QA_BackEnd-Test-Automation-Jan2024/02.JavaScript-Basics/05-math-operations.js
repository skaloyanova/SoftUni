function mathOperation(a, b, operand) {
    'use strict'
    // The string may be one of the following: '+', '-', '*', '/', '%', '**'.

    let result;

    switch(operand) {
        case '+': result = a + b; break; 
        case '-': result = a - b; break; 
        case '*': result = a * b; break; 
        case '/': result = a / b; break; 
        case '%': result = a % b; break; 
        case '**': result = a ** b; break;
        default: return;
    }

    console.log(result);
}

mathOperation(5, 6, '+');   // 11
mathOperation(5, 6, '-');   // -1
mathOperation(3, 5.5, '*'); // 16.5
mathOperation(7, 2, '/');   // 3.5
mathOperation(15, 4, '%');  // 3
mathOperation(3, 4, '**');  // 81
mathOperation(3, 4, 'aaa'); // 