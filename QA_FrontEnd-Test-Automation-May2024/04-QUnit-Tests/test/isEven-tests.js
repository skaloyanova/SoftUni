const { isEven } = require("../test_functions.js");

QUnit.module('test isEven function', () => {
    QUnit.test('test with even number', (assert) => {
        assert.ok(isEven(4), 'should return true')
    })
    QUnit.test('test with odd number', (assert) => {
        assert.notOk(isEven(5), 'should return false')
    })
    QUnit.test('test with 0', (assert) => {
        assert.ok(isEven(0), 'should return true')
    })
    QUnit.test('test with negative even number', (assert) => {
        assert.ok(isEven(-4), 'should return true')
    })
    QUnit.test('test with negative odd number', (assert) => {
        assert.notOk(isEven(-5), 'should return false')
    })
})