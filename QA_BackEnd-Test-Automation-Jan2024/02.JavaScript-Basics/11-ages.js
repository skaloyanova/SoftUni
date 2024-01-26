function age(age) {
    'use strict'

    let resut;

    if (age < 0) {
        resut = "out of bounds";
    } else if (age <= 2) {
        resut = "baby";
    } else if (age <= 13) {
        resut = "child";
    } else if (age <= 19) {
        resut = "teenager";
    } else if (age <= 65) {
        resut = "adult";
    } else {
        resut = "elder";
    }

    console.log(resut);
}

age(20);
age(1);
age(100);
age(-1);
