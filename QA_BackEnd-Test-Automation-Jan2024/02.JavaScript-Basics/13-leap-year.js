function leap(year) {
    'use strict'

    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
        console.log('yes');
    } else {
        console.log('no');
    }
}

leap(1984);
leap(2003);
leap(4);