//You will receive an array of names. 
//Sort them alphabetically in ascending order and print a numbered list of all the names, each on a new line.

function sortAndPrintArray(inputArray) {
    'use strict';

    inputArray.sort((a, b) => a.localeCompare(b));

    let cnt = 1;

    for (const item of inputArray) {
        console.log(`${cnt++}.${item}`);
    }
}

sortAndPrintArray(["John", "Bob", "Christina", "Ema"]);

// 1.Bob
// 2.Christina
// 3.Ema
// 4.John

sortAndPrintArray(["John"]);
sortAndPrintArray([]);