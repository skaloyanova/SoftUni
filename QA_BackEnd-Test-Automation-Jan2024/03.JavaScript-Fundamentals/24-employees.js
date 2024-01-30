//You will receive an array of strings. 
//Each string is an employee name and to assign them a personal number you have to find the length of the name (whitespace included). 

function employees(inputArray) {
    'use strict';

    let employeeList = {};

    inputArray.forEach(name => employeeList[name] = name.length);   //create object with key (employee's name) and value (personal number, name length)

    for (const key in employeeList) {
        console.log(`Name: ${key} -- Personal Number: ${employeeList[key]}`);
    }
}

// VARIANT 2 //
function employees2(inputArray) {
    'use strict';

    let employeeList = [];

    for (const employee of inputArray) {
        employeeList.push({
            name: employee,
            personalNumber: employee.length
        })
    }

    employeeList.forEach(e => console.log(`Name: ${e.name} -- Personal Number: ${e.personalNumber}`));
}

// VARIANT 2 //
function employees3(inputArray) {
    'use strict';

    inputArray.map(e => ({
        name: e,
        personalNumber: e.length
    }))
        .forEach(e => console.log(`Name: ${e.name} -- Personal Number: ${e.personalNumber}`));
}

//test data

employees3([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]);
console.log('');
employees3([
    'Samuel Jackson',
    'Will Smith',
    'Bruce Willis',
    'Tom Holland'
]);