/*
Write a program, which receives a number n and an array of elements. 
Create a new array with n numbers from the original array, reverse it and print its elements on a single line, space-separated.
*/
function reverseArray(size, array) {
    'use strict';

    let newArray = array.slice(0, size);
    newArray.reverse();

    console.log(newArray.join(' '));
}

reverseArray(3, [10, 20, 30, 40, 50]);  //30 20 10
reverseArray(4, [-1, 20, 99, 5]);       //5 99 20 -1
reverseArray(2, [66, 43, 75, 89, 47]);  //43 66