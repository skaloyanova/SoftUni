function vacation(groupCount, typeOfGroup, weekDay) {
    'use strict'

    let price = 0;

    if (typeOfGroup === 'Students') {
        switch (weekDay) {
            case 'Friday': price = 8.45; break;
            case 'Saturday': price = 9.80; break;
            case 'Sunday': price = 10.46; break;
        }

        if (groupCount >= 30) {
            price *= 0.85;  //discount 15%
        }

    } else if (typeOfGroup === 'Business') {
        switch (weekDay) {
            case 'Friday': price = 10.90; break;
            case 'Saturday': price = 15.60; break;
            case 'Sunday': price = 16; break;
        }

        if (groupCount >= 100) {
            groupCount -= 10;  //10 of them can stay for free
        }

    } else if (typeOfGroup === 'Regular') {
        switch (weekDay) {
            case 'Friday': price = 15; break;
            case 'Saturday': price = 20; break;
            case 'Sunday': price = 22.50; break;
        }

        if (groupCount >= 10 && groupCount <= 20) {
            price *= 0.95;  //discount 5%
        }
    }

    let totalPrice = groupCount * price;
    console.log(`Total price: ${totalPrice.toFixed(2)}`);

}

vacation(30, "Students", "Sunday");     //Total price: 266.73
vacation(40, "Regular", "Saturday");    //Total price: 800.00
vacation(100, "Business", "Friday");     //Total price: 981.00