//Calculates the difference between the sum of the even and the sum of the odd numbers in an array

function evenOddSumDifference(array) {
    'use strict';
    
    let evenSum = 0;
    let oddSum = 0;

    for (const num of array) {
        const currentNum = parseInt(num);

        if (currentNum % 2 == 0) {
            evenSum += currentNum;
        } else {
            oddSum += currentNum;
        }
    }

    console.log(evenSum - oddSum);
}

evenOddSumDifference([1,2,3,4,5,6]);    //3
evenOddSumDifference([3,5,7,9]);        //-24
evenOddSumDifference([2,4,6,8,10]);     //30


// works only if there are both odd and even elements, else either of the new arrays gets empty
// and provides error when trying to reduce it
function evenOddSumDifference2(array) {
    'use strict';
    
    let evenSum = array.filter(x => x % 2 === 0).reduce((sum, x) => sum + x);
    let oddSum = array.filter(x => x % 2 !== 0).reduce((sum, x) => sum + x);

    console.log(evenSum - oddSum);
}

evenOddSumDifference2([1,2,3,4,5,6]);    //3
