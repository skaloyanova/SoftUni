import { isOddOrEven } from './05-is-odd-or-even.js'
import { expect } from 'chai'

describe('isOddOrEven(string)', () => {
    it('should return "even" when "Stanislava" is given', () => {
        //Arrange
        const input = 'Stanislava';
        //Act
        const result = isOddOrEven(input);
        //Assert
        expect(result).to.be.equal('even');
    })

    it('should return "odd" when "Stani" is given', () => {
        //Arrange
        const input = 'Stani';
        //Act
        const result = isOddOrEven(input);
        //Assert
        expect(result).to.be.equal('odd');
    })


    it('should return "even" when " Stanislava with spaces " is given', () => {
        //Arrange
        const input = ' Stanislava with spaces ';
        //Act
        const result = isOddOrEven(input);
        //Assert
        expect(result).to.be.equal('even');
    })

    it('should return "even" when empty string is given', () => {
        //Arrange
        const input = '';
        //Act
        const result = isOddOrEven(input);
        //Assert
        expect(result).to.be.equal('even');
    })

    it('should return "odd" when string contains 5 spaces is given', () => {
        //Arrange
        const input = '     ';
        //Act
        const result = isOddOrEven(input);
        //Assert
        expect(result).to.be.equal('odd');
    })
    
    it('should return "undefined" when non-string is given (number, boolean, array, object)', () => {
        //Act
        const result1 = isOddOrEven(123);
        const result2 = isOddOrEven(false);
        const result3 = isOddOrEven([1, 2]);
        const result4 = isOddOrEven({});
        //Assert
        expect(result1).undefined;
        expect(result2).undefined;
        expect(result3).undefined;
        expect(result4).undefined;
    })

    it('should return "undefined" when non-string is given (null, NaN, undefined)', () => {
        const result1 = isOddOrEven(null);
        const result2 = isOddOrEven(NaN);
        const result3 = isOddOrEven(undefined);
        //Assert
        expect(result1).undefined;
        expect(result2).undefined;
        expect(result3).undefined;
    })
})