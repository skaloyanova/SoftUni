function cooking(num, op1, op2, op3, op4, op5) {
    'use strict';

    let result = parseInt(num, 10);
    const operations = [op1, op2, op3, op4, op5];

    for (const operation of operations) {
        switch(operation) {
            case 'chop': result /= 2; break;
            case 'dice': result = Math.sqrt(result); break;
            case 'spice': result += 1; break;
            case 'bake': result *= 3; break;
            //case 'fillet': result *= 0.80; break;
            case 'fillet': result -= result * 0.2; break;
        }

        console.log(result);
    }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');