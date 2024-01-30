function stringSubstring(word, text) {
    'use strict';

    let regex = new RegExp(`\\b${word}`, 'i');  //case-insensitive
    const matches = text.match(regex);

    if(matches) {
        console.log(word);
    } else {
        console.log(word + ' not found!');
    }
}

stringSubstring('javascript', 'JavaScript is the best programming language');
stringSubstring('python', 'JavaScript is the best programming language');