function gradeFormat(grade) {
    'use strict';

    grade = Number(grade);

    let gradeDescription = '';

    if (grade < 3.00) {
        gradeDescription = 'Fail';
    } else if (grade < 3.50) {
        gradeDescription = 'Poor';
    } else if (grade < 4.50) {
        gradeDescription = 'Good';
    } else if (grade < 5.50) {
        gradeDescription = 'Very good';
    } else {
        gradeDescription = 'Excellent';
    }

    if (grade < 3) {
        console.log(`${gradeDescription} (2)`);
    } else {
        console.log(`${gradeDescription} (${grade.toFixed(2)})`);
    }
}

gradeFormat(3.33);  //Poor (3.33)
gradeFormat(4.50);  //Very good (4.50)
gradeFormat(2.99);  //Fail (2)