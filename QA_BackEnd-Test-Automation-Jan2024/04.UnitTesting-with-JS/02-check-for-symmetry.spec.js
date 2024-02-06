import { expect } from 'chai';
import { isSymmetric } from './02-check-for-symmetry.js';

describe('isSymmetric(arr)', () => {
    it('should return false if invalid input (number, boolean, string, object) is given', () => {
        //Act
        const numberResult = isSymmetric(56);
        const booleanResult = isSymmetric(true);
        const stringResult = isSymmetric('2 3 1 3 2');
        const objectResult = isSymmetric({})

        //Assert
        expect(numberResult).false;
        expect(booleanResult).false;
        expect(stringResult).false;
        expect(objectResult).false;
    })
    it('should return false if invalid input (NaN, undefined, null) is given', () => {
        //Act
        const nanResult = isSymmetric(NaN);
        const undefinedResult = isSymmetric(undefined);
        const nullResult = isSymmetric(null);

        //Assert
        expect(nanResult).false;
        expect(undefinedResult).false;
        expect(nullResult).false;
    })
    it('should return true if symmetric array (with numbers) is given', () => {
        //Arrange
        const input = [2, 3, 1, 3, 2];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).true;
    })
    it('should return true if symmetric array (with strings) is given', () => {
        //Arrange
        const input = ['a', 'bb', 'ccc', 'ccc', 'bb', 'a'];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).true;
    })
    it('should return false if non-symmetric (numbers) array is given', () => {
        //Arrange
        const input = [2, 31, 31, 3, 2];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).false;
    })
    it('should return false if non-symmetric array (strings) is given', () => {
        //Arrange
        const input = ['a', 'bb', 'cc', 'ccc', 'bb', 'a'];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).false;
    })
    it('should return true if array with 1 element is given', () => {
        //Arrange
        const input = [100];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).true;
    })
    it('should return true if empty array is given', () => {
        //Arrange
        const input = [];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).true;
    })
    it('should return false if array that looks like symmetric (mixed numbers and number as string) is given', () => {
        //Arrange
        const input = [1, '2', '3', 2, 1];

        //Act
        const result = isSymmetric(input);

        //Assert
        expect(result).false;
    })
})
