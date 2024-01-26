function radar(speed, area) {
    'use strict';

    let speedLimit = 0;

    switch (area) {
        case 'motorway': speedLimit = 130; break;
        case 'interstate': speedLimit = 90; break;
        case 'city': speedLimit = 50; break;
        case 'residential': speedLimit = 20; break;
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        const diff = speed - speedLimit;
        let status = '';

        if(diff <= 20) {
            status = 'speeding'
        } else if (diff <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

radar(40, 'city');
radar(21, 'residential');
radar(120, 'interstate');
radar(200, 'motorway');