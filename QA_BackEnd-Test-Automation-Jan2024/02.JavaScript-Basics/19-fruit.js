function fruit(fruit, weightInGrams, pricePerKilogram) {
    'use strict';

    let weightInKilogram = weightInGrams / 1000;

    let money = weightInKilogram * pricePerKilogram;

    console.log(`I need $${money.toFixed(2)} to buy ${weightInKilogram.toFixed(2)} kilograms ${fruit}.`);
}

fruit('orange', 2500, 1.80);
fruit('apple', 1563, 2.35);