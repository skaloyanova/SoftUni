//Write a function that receives a string and two numbers.
//The numbers will be a starting index and count of elements to substring. Print the result.

function substr(text, startIndex, numberOfChars) {
    'use strict';

    let endIndex = startIndex + numberOfChars;
    console.log(text.substring(startIndex, endIndex));
}

substr('ASentence', 1, 8);   //Sentence
substr('SkipWord', 4, 7);    //Word