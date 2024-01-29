/*
Write a function that stores information about a person's name and phone number. 
The input is an array of strings with space-separated name and number. Replace duplicate names
*/

function phonebookPrint(inputArray) {
    'use strict';

    let phonebook = {};

    for (const element of inputArray) {
        const split = element.split(' ');
        const key = split[0];
        const value = split[1];

        phonebook[key] = value;
    }

    const entries = Object.entries(phonebook);
    entries.forEach((e) => console.log(e.join(' -> ')));
}

phonebookPrint(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']);

phonebookPrint(['George 0552554',
    'Peter 087587',
    'George 0453112',
    'Bill 0845344']);