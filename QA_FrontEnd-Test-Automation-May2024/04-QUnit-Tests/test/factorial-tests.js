const {factorial} = require('../test_functions.js');

QUnit.module('test factorial function', () => {
    QUnit.test('pass 5 as parameter, get 120 as a result', (assert) => {
        assert.equal(factorial(5), 120, 'f(5) should return 120')
    })

    QUnit.test('pass 0 as parameter, get 1 as a result', (assert) => {
        assert.equal(factorial(5), 120, 'f(0) should return 1')
    })

    QUnit.test('pass -1 as parameter, get 1 as a result', (assert) => {
        assert.equal(factorial(5), 120, 'f(-1) should return 1')
    })
})