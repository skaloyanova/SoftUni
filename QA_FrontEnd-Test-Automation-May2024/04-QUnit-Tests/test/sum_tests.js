const { sum } = require("../test_functions.js");

QUnit.module('sum function tests', () => {
    QUnit.test("sum two numbers", (assert) => {
        assert.equal(sum(2, 3), 5, "2 + 3 should be 5");
    })
})