function theatre(dayType, age) {
    'use strict'

    let price;
    let isValid = true;

    if (age >= 0 && age <= 18) {
        switch (dayType) {
            case 'Weekday': price = 12; break;
            case 'Weekend': price = 15; break;
            case 'Holiday': price = 5; break;
        }
    } else if (age > 18 && age <= 64) {
        switch (dayType) {
            case 'Weekday': price = 18; break;
            case 'Weekend': price = 20; break;
            case 'Holiday': price = 12; break;
        }
    } else if (age > 64 && age <= 122) {
        switch (dayType) {
            case 'Weekday': price = 12; break;
            case 'Weekend': price = 15; break;
            case 'Holiday': price = 10; break;
        }
    } 

    if (price) {
        console.log(price + '$');
    } else {
        console.log('Error!');
    }
    
}

theatre('Weekday', 42)
theatre('Holiday', -12)
theatre('Holiday', 15)