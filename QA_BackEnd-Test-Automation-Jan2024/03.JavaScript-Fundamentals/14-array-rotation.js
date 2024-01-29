function arrayRotation(array, rotationCount) {
    'use strict';

    const rotations = parseInt(rotationCount) % array.length;
    let rotatedArray = array.slice();

    for(let i = 0 ; i < rotations; i++) {
        rotatedArray.push(rotatedArray.shift());
    }

    console.log(rotatedArray.join(' '));
}

arrayRotation([51, 47, 32, 61, 21], 2);     //32 61 21 51 47
arrayRotation([32, 21, 61, 1], 4);          //32 21 61 1
arrayRotation([2, 4, 15, 31], 5);           //4 15 31 2