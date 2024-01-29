function printArray(inputArray, step) {
    'use strict';

    let newArray = [];

    if(step <= 0) return [];

    for(let i = 0; i < inputArray.length; i += step) {
        newArray.push(inputArray[i]);
    }
    return newArray;
}

console.log(printArray(['5', '20', '31', '4', '20'], 2));        //['5', '31', '20']
console.log(printArray(['dsa', 'asd', 'test', 'tset'], 2));      //['dsa', 'test']
console.log(printArray(['1', '2', '3', '4', '5'], 6));           //['1']
console.log(printArray([], 6));                                  //[]
console.log(printArray(['1', '2', '3', '4', '5'], 0));           //[]
console.log(printArray(['1', '2', '3', '4', '5'], -3));          //[]