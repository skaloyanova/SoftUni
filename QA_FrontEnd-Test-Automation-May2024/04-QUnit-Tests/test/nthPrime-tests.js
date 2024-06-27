const {nthPrime} = require('../test_functions.js');

QUnit.module('testing nthPrime function', () => {
    QUnit.test('given parameter 1, returns 2', (assert) => {
        assert.equal(nthPrime(1), 2, 'f(1) should return 2');
    })
    QUnit.test('given parameter 5, returns 11', (assert) => {
        assert.equal(nthPrime(5), 11, 'f(5) should return 11');
    })
    QUnit.test('given parameter 11, returns 31', (assert) => {
        assert.equal(nthPrime(11), 31, 'f(11) should return 31');
    })
})