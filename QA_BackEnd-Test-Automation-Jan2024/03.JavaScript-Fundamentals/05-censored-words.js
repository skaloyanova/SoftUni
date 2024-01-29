function censore(text, wordToCensore) {
    'use strict';

    const regex = new RegExp(wordToCensore, 'gi');
    const replacementWord = '*'.repeat(wordToCensore.length);
    
    const censoredText = text.replace(regex, replacementWord)

    console.log(censoredText);
}

censore('A small sentence with some words', 'small');   //A ***** sentence with some words
censore('Find the hidden word', 'hidden');              //Find the ****** word
censore('May I have some tea, please. Some milk and some sugar would be nice too.', 'some');    //May I have **** tea, please. **** milk and **** sugar would be nice too.