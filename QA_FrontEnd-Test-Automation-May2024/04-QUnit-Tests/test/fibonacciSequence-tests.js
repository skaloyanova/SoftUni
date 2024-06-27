const {fibonacciSequence} = require('../test_functions.js');

QUnit.module('testing fibonacciSequence function', () => {
    QUnit.test('pass 0 as parameter, get empty array', assert => {
        assert.deepEqual(fibonacciSequence(0), [],'f(0) should return []')
    })
    QUnit.test('pass 1 as parameter, get [0]', assert => {
        assert.deepEqual(fibonacciSequence(1), [0],'f(1) should return [0]')
    })
    QUnit.test('pass 5 as parameter, get [0, 1, 1, 2, 3]', assert => {
        assert.deepEqual(fibonacciSequence(5), [0, 1, 1, 2, 3],'f(5) should return [0, 1, 1, 2, 3]')
    })
    QUnit.test('pass 10 as parameter, get [0, 1, 1, 2, 3, 5, 8, 13, 21, 34]', assert => {
        assert.deepEqual(fibonacciSequence(10), [0, 1, 1, 2, 3, 5, 8, 13, 21, 34],'f(10) should return [0, 1, 1, 2, 3, 5, 8, 13, 21, 34]')
    })
})