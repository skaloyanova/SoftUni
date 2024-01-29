function revealWords(words, text) {
    'use strict';

    let listOfWords = words.split(', ');

    let textArray = text.split(' ');

    for(let i = 0; i < textArray.length; i++) {
        let currentElement = textArray[i];

        for(let j = 0; j <listOfWords.length; j++) {
            const currentWord = listOfWords[j];

            if (currentElement === '*'.repeat(currentWord.length)) {
                textArray[i] = currentWord;
                listOfWords.splice(j, 1);
            }
        }
    }

    console.log(textArray.join(' '));
}

revealWords('great', 'softuni is ***** place for learning new programming languages');
revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');
revealWords('be, BabyD, let, your', '*** me ** **** fantasy - *****');      //Let me be your fantasy - BabyD
