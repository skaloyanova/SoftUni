// Sort an array of numbers so that the first element is the smallest one, the second is the biggest one, 
//  the third is the second smallest one, the fourth is the second biggest one, and so on. 
// Return the resulting array

function sortArray(inputArray) {
    'use strict';

    inputArray.sort((a,b) => {return (a > b) ? 1 : (a < b) ? -1 : 0});

    let sortedArray = [];

    while (inputArray.length > 0) {
        sortedArray.push(inputArray.shift());

        if (inputArray.length === 0) { 
            break; 
        }

        sortedArray.push(inputArray.pop());
    }

    return sortedArray;
}


console.log(sortArray([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));  // [-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]
console.log(sortArray([1, 65, 3, 52, 63, 31, -3, 18, 56]));  // [-3, 65, 1, 63, 3, 56, 18, 52, 31]
