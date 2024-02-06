import { sum } from "./01-sum.js"
import { assert, expect } from 'chai'

describe ('sum(arr)', () => {
    it ('should return 0, if empty array is given', () => {
        //Arrange
        const inputArray = [];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equals(0);
    })

    it ('should return single element sum, is single array element is given', () => {
        //Arrange
        const inputArray = [77];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equals(77);
    })

    it ('should return total sum of an array, if multi-value is given', () => {
        //Arrange
        const inputArray = [1, 0, 4];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equals(5);
    })


    describe('Second describe for test', () => {
        it ('should return true', () => {expect(true).to.be.true})
    })

})