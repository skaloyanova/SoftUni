const {isPerfectSquare} = require('../test_functions.js');

QUnit.module('testing isPerfectSquare function', () => {
    QUnit.test('when parameter 1 is given, should return true', assert => {
        assert.ok(isPerfectSquare(1), 'f(1) should return true')
    })
    QUnit.test('when parameter 4 is given, should return true', assert => {
        assert.ok(isPerfectSquare(4), 'f(4) should return true')
    })
    QUnit.test('when parameter 9 is given, should return true', assert => {
        assert.ok(isPerfectSquare(9), 'f(9) should return true')
    })
    QUnit.test('when parameter 16 is given, should return true', assert => {
        assert.ok(isPerfectSquare(16), 'f(16) should return true')
    })
    QUnit.test('when parameter 2 is given, should return false', assert => {
        assert.notOk(isPerfectSquare(2), 'f(2) should return false')
    })
    QUnit.test('when parameter 15 is given, should return false', assert => {
        assert.notOk(isPerfectSquare(15), 'f(15) should return false')
    })
})