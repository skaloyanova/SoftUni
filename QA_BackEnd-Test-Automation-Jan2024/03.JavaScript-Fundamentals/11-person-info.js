function personInfo(firstName, lastName, age) {
    'use strict';

    const person = {
        'firstName': firstName,
        'lastName': lastName,
        'age': age
    }

    return person;

    // for (const key in person) {
    //     console.log(`${key}: ${person[key]}`);

    // }
}

// personInfo("Peter", "Pan", "20");
// personInfo("George", "Smith", "18");