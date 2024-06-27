const {pascalTriangle} = require('../test_functions.js');

QUnit.module('testing pascalTriangle function', () => {
    QUnit.test('when parameter is 0, returns empty jagged array', assert => {
        assert.deepEqual(pascalTriangle(0), [], 'f(0) should return []')
    })
    QUnit.test('when parameter is 1, returns [1]', assert => {
        assert.deepEqual(pascalTriangle(1), [[1]], 'f(1) should return [1]')
    })
    QUnit.test('when parameter is 5, returns jagged array [1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]', assert => {
        assert.deepEqual(pascalTriangle(5), [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]], 'f(5) should return [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]]')
    })
    QUnit.test('when parameter is 8, returns jagged array [1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1], [1, 5, 10, 10, 5, 1], [1, 6, 15, 20, 15, 6, 1], [1, 7, 21, 35, 35, 21, 7, 1]', assert => {
        assert.deepEqual(pascalTriangle(8), [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1], [1, 5, 10, 10, 5, 1], [1, 6, 15, 20, 15, 6, 1], [1, 7, 21, 35, 35, 21, 7, 1]], 'f(8) should return [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1], [1, 5, 10, 10, 5, 1], [1, 6, 15, 20, 15, 6, 1], [1, 7, 21, 35, 35, 21, 7, 1]]')
    })
})
