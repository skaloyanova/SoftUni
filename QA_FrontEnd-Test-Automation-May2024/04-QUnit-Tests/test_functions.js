function sum(a, b) {
    return a + b;
}

function isEven(num) {
    return num % 2 === 0 ? true : false;
}

function factorial(n) {
    if (n <= 1) {
        return 1;
    }
    return n * factorial(n - 1);
}

function isPalindrome(word) {
    if (word === '') {
        return false;
    }
    let convertedWord = word.toLowerCase().replaceAll(/[\W+_]/g, '');
    let reversedWord = Array.from(convertedWord).reverse().join('');

    return word === reversedWord;
}

function fibonacciSequence(n) {
    if (n <= 0) {
        return [];
    }
    if (n === 1) {
        return [0];
    }

    let sequence = [0, 1];

    for (let i = 2; i < n; i++) {
        const sum = sequence[sequence.length - 1] + sequence[sequence.length - 2];
        sequence.push(sum);
    }

    return sequence;
}

function nthPrime(n) {

    if (n < 1) {
        throw new Error('invalid argument');
    }
    let primeCounter = 0;
    let currentNum = 1;

    while (true) {
        if (isPrime(currentNum)) {
            primeCounter++;
            if (n === primeCounter) {
                return currentNum;
            }
        }
        currentNum++;
    }

    function isPrime(num) {
        if (num <= 1) {
            return false;
        }

        for (let i = 2; i < num; i++) {
            if (num % i === 0) {
                return false;
            }
        }
        return true;
    }
}

function pascalTriangle(rows) {
    let triangle = [];

    for (let i = 0; i <= rows; i++) {
        triangle[i] = [];
        triangle[i][0] = 1;

        for (let j = 1; j < i; j++) {
            triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];

        }
        triangle[i][i] = 1;
    }
    return triangle;
}

function isPerfectSquare(num) {
    return Math.sqrt(num) % 1 === 0;
}

module.exports = {
    sum,
    isEven,
    factorial,
    isPalindrome,
    fibonacciSequence,
    nthPrime,
    pascalTriangle,
    isPerfectSquare
}