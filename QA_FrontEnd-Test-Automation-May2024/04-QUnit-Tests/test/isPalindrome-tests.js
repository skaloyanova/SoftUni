const {isPalindrome} = require('../test_functions.js');

QUnit.module('testing isPalindrome function', () => {
    QUnit.test('test with "racecar"', (assert) => {
        assert.ok(isPalindrome('racecar'), 'should return true')
    })
    QUnit.test('test with "A man, a plan, a canal, Panama!"', (assert) => {
        assert.ok(isPalindrome('A man, a plan, a canal, Panama!'), 'should return true')
    })
    QUnit.test('test with "hello"', (assert) => {
        assert.notOk(isPalindrome('hello'), 'should return false')
    })
    QUnit.test('test with empty string', (assert) => {
        assert.notOk(isPalindrome(''), 'should return false')
    })
})