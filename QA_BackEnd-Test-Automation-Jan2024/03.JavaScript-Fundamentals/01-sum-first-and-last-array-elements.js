function sum(array) {
    'use strict';
    
    console.log(array[0] + array[array.length - 1])
}

sum([20, 30, 40]);      //60
sum([10, 17, 22, 33]);  //43
sum([11, 58, 69]);      //80