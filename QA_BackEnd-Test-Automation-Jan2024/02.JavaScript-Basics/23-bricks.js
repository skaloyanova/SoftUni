/*
* Строителни работници трябва да пренесат общо x тухли. 
* Работниците са w на брой и работят едновременно. 
* Те превозват тухлите в колички, всяка с вместимост m тухли. 
* Напишете програма, която прочита целите числа x (бр. тухли), w (бр. работници) и m (вместимост на количката) 
*    и пресмята колко най-малко курса трябва да направят работниците, за да превозят тухлите.
*/

function bricks([bricks, workers, cartCapacity]) {
    //'use strict';

    const cartsNeeded = Math.ceil(bricks / cartCapacity);
    const coursesNeeded = Math.ceil(cartsNeeded / workers);

    console.log(coursesNeeded);

}

bricks([120, 2, 30]);     // 2
bricks([355, 3, 10]);     // 12
bricks([5, 12, 30]);      // 1