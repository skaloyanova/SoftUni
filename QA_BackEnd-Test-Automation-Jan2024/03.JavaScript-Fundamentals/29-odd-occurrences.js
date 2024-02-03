//Write a function that extracts the elements of a sentence, if it appears an odd number of times (case-insensitive).
//The input comes as a single string. The words will be separated by a single space.

function oddOccurences(text){
    'use strict';

    let occurences = {};
    const words = text.toLowerCase().split(' ');
    
    for (const word of words) {
        if (occurences[word]) {
            occurences[word] += 1;
        } else {
            occurences[word] = 1;
        }
    }

    let oddOccurences = Object.keys(occurences).filter(word => occurences[word] % 2 !== 0);
    console.log(oddOccurences.join(' '));
}

// test data
oddOccurences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
console.log('');
oddOccurences('Cake IS SWEET is Soft CAKE sweet Food');