function countWords(text, word) {
    'use strict';

    const regex = new RegExp(`\\b${word}`, 'g');
    const matches = text.match(regex) || [];    //if there are no matches instead of null, const matches will get empty array

    console.log(matches.length);
}

countWords('This is a word and it also is a sentence', 'is');   //2
countWords('softuni is great place for learning new programming languages', 'softuni'); //1
countWords('no matching words', 'abc');     //0


/**** VARIANT 2******/
function countWords2(text, word) {
    'use strict';

    const words = text.split(' ');
    let count = 0;

    for (const w of words) {
        if (w === word) {
            count++;
        }
    }

    console.log(count);
}

countWords2('This is a word and it also is a sentence', 'is');   //2
countWords2('softuni is great place for learning new programming languages', 'softuni'); //1
countWords2('no matching words', 'abc');    //0