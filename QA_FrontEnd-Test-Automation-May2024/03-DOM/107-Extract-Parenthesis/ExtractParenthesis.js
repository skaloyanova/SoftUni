function extract(elementId) {
    const elementContent = document.getElementById(elementId).textContent;

    let wordList = [];

    const regex = new RegExp('\\((.*?)\\)', 'gm')
    const matches = elementContent.matchAll(regex);

    for (const match of matches) {
        wordList.push(match[1]);
    }

   return wordList.join('; ');
}


// function extract(elementId) {
//     const elementContent = document.getElementById(elementId).textContent;

//     let openBracket = false;
//     let endWord = false;

//     let word = '';
//     let wordList = [];

//     for (let i = 0; i < elementContent.length; i++) {
//         const char = elementContent[i];

//         if(char === ')' && openBracket) {
//             openBracket = false;
//             endWord = true;
//         } 

//         if(openBracket) {
//             word += char;
//         }

//         if(endWord) {
//             wordList.push(word);
//             word = '';
//             endWord = false;
//         }

//         if(char === '(') {
//             openBracket = true;
//         } 
//     }

//     return wordList.join('; ');
// }
