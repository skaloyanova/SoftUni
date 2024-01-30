/*
You will receive two arrays. All of the arrays’ values will be strings.

The first array represents the current stock of the local store. 
The second array will contain products that the store has ordered for delivery.

The following information applies to both arrays:
    Every even index will hold the name of the product and every odd index will hold the quantity of that product. 
    The second array could contain products that are already in the local store. 
    If that happens increase the quantity for the given product. You should store them into an object, and print them in the following format: (product -> quantity)
*/

function store(stockArray, deliveryArray) {
    'use strict';

    let products = {};

    for (let i = 0; i < stockArray.length; i += 2) {
        const product = stockArray[i];
        const quantity = Number(stockArray[i + 1]);

        products[`${product}`] = quantity;
    }

    for (let i = 0; i < deliveryArray.length; i += 2) {
        const product = deliveryArray[i];
        const quantity = Number(deliveryArray[i + 1]);

        const productCurrentQuantity = products[product];
        const newQuantity = productCurrentQuantity ? quantity + productCurrentQuantity : quantity
        products[`${product}`] = newQuantity;
    }

    for (const product in products) {
        console.log(`${product} -> ${products[product]}`);
    }
}

// test data
store(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);

// Chips -> 5
// CocaCola -> 9
// Bananas -> 44
// Pasta -> 11
// Beer -> 2
// Flour -> 44
// Oil -> 12
// Tomatoes -> 70


console.log('');
store(['Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'],
    ['Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30']);

// Salt -> 2
// Fanta -> 4
// Apple -> 21
// Water -> 4
// Juice -> 5
// Sugar -> 44
// Oil -> 12
// Tomatoes -> 7
// Bananas -> 30
