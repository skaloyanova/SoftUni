function towns(inputArray) {
    'use strict';

    let townsList = [];

    for (const item of inputArray) {
        const townData = item.split(' | ');

        townsList.push({
            town: townData[0],
            latitude: Number(townData[1]).toFixed(2),
            longitude: Number(townData[2]).toFixed(2)
        })
    }

    townsList.forEach(town => console.log(town));
}

// test data

towns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
// { town: 'Sofia', latitude: '42.70', longitude: '23.33' }
// { town: 'Beijing', latitude: '39.91', longitude: '116.36' }

console.log('');
towns(['Plovdiv | 136.45 | 812.575']);  //{ town: 'Plovdiv', latitude: '136.45', longitude: '812.58' }