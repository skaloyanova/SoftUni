function calculateTotalPrice(product, quantity) {
    'use strict';

    let productPrice = 0;

    switch(product) {
        case 'coffee': productPrice = 1.50; break;
        case 'water': productPrice = 1.00; break;
        case 'coke': productPrice = 1.40; break;
        case 'snacks': productPrice = 2.00; break;
        default: return;
    }

    const totalPrice = productPrice * parseInt(quantity);
    console.log(totalPrice.toFixed(2));
}

calculateTotalPrice("water", 5);    //5.00
calculateTotalPrice("coffee", 2);   //3.00