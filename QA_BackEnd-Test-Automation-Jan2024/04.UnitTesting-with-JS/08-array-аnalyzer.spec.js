import { analyzeArray } from './08-array-аnalyzer.js';
import { expect } from 'chai';

describe('analyzeArray(arr)', () => {
    it('should return "undefined" if non-array is given (string, number, object, boolean, null, NaN, undefinded)', () => {
        expect(analyzeArray('10')).to.be.undefined;
        expect(analyzeArray(10)).to.be.undefined;
        expect(analyzeArray({})).to.be.undefined;
        expect(analyzeArray(true)).to.be.undefined;
        expect(analyzeArray(null)).to.be.undefined;
        expect(analyzeArray(NaN)).to.be.undefined;
        expect(analyzeArray(undefined)).to.be.undefined;
    })

    it('should return "undefined" if empty array is given', () => {
        expect(analyzeArray([])).to.be.undefined;
    })

    it('should return "undefined" if array element is not a number (string, array, object, boolean, null, undefinded)', () => {
        expect(analyzeArray([1, '10'])).to.be.undefined;
        expect(analyzeArray([10, [1]])).to.be.undefined;
        expect(analyzeArray([1, {}])).to.be.undefined;
        expect(analyzeArray([1, true])).to.be.undefined;
        expect(analyzeArray([1, null])).to.be.undefined;
        expect(analyzeArray([1, undefined])).to.be.undefined;
    })

    it('should return correct result when array with single element is given', () => {
        expect(analyzeArray([123])).deep.equal({min: 123, max: 123, length: 1});
    })

    it('should return correct result when array with equal elements is given', () => {
        expect(analyzeArray([12, 12, 12, 12, 12, 12])).deep.equal({min: 12, max: 12, length: 6});
    })

    it('should return correct result when array with miltiple different elements is given', () => {
        //Arrange
        const input = [1, 0, 6, -12, 50, 59, -3, 7, -12, 50];
        //Act
        const result = analyzeArray(input);
        const expected = {min: -12, max: 59, length: 10};
        //Assert
        expect(result).deep.equals(expected);
    })
})