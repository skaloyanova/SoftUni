/*
Write a function that:
•	Records a car number for every car that enters the parking lot
•	Removes a car number when the car goes out
•	Input will be an array of strings in format [direction, carNumber]
Print the output with all car numbers which are in the parking lot sorted in ascending order by number.
If the parking lot is empty, print: "Parking Lot is Empty".
*/

function piccolo(inputArr) {
    'use strict';

    let parking = [];

    for (const entry of inputArr) {
        const [direction, carNumber] = entry.split(', ');

        if (direction === 'IN') {
            parking.push(carNumber);
        } else if (direction === 'OUT') {
            parking.splice(parking.indexOf(carNumber), 1);
        }
    }

    if (parking.length > 0) {
        parking.sort((a, b) => a.localeCompare(b)).forEach(c => console.log(c));
    } else {
        console.log('Parking Lot is Empty');
    }
}

// workaround solution for Judge, about sorting problem
function piccolo2(inputArr) {
    'use strict';

    let parking = new Set();

    for (const entry of inputArr) {
        const [direction, carNumber] = entry.split(', ');

        if (direction === 'IN') {
            parking.add(carNumber);
        } else if (direction === 'OUT') {
            parking.delete(carNumber);
        }
    }

    if (parking.size > 0) {
        Array.from(parking).sort((a, b) => a.localeCompare(b)).forEach(c => console.log(c));
    } else {
        console.log('Parking Lot is Empty');
    }
}

//test data
piccolo2(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']);

console.log('');
piccolo2(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']);
