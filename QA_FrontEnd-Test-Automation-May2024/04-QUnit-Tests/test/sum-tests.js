const { sum } = require("../test_functions.js");

QUnit.module('sum function tests', () => {
    QUnit.test('sum two possitive numbers', (assert) => {
        assert.equal(sum(2, 3), 5, "2 + 3 should be 5");
    });
    QUnit.test('sum two negative numbers', (assert) => {
        assert.equal(sum(-2, -6), -8, '-2 - 6 should be -8');
    });
    QUnit.test('sum possitive and negative number', (assert) => {
        assert.equal(sum(2, -6), -4, '2 - 6 should be -4');
    });
    QUnit.test('sum real numbers', (assert) => {
        assert.equal(Math.floor(sum(0.1, 1.3) * 10), 14, '0.1 + 1.3 should be 1.4');
    });
})
