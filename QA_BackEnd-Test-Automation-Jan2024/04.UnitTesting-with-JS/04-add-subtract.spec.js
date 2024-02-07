import { createCalculator } from './04-add-subtract.js'
import { expect } from 'chai'

describe('createCalculator()', () => {
    it('should return 0 if no calculate operations are performed', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        const result = calculator.get();
        //Assert
        expect(result).equals(0);
    })

    it('should return positive number if only "add" operation is performed with positive numbers', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.add(4);
        calculator.add(0);
        calculator.add(1);
        const result = calculator.get();
        //Assert
        expect(result).equals(5);
    })
    
    it('should return negative number if only "subtract" operation is performed with positive numbers', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.subtract(10);
        calculator.subtract(0);
        calculator.subtract(13);
        const result = calculator.get();
        //Assert
        expect(result).equals(-23);
    })

    it('should return correct result if multiple operations are performed with decimal numbers', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.subtract(10.5);
        calculator.add(3.1);
        calculator.add(4.6);
        const result = calculator.get();
        //Assert
        expect(result).closeTo(-2.8, 0.0001);
    })

    it('should return correct result if multiple operations are performed and input is mixed (string / number)', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.subtract('5');
        calculator.add(3);
        calculator.add('4');
        const result = calculator.get();
        //Assert
        expect(result).equals(2);
    })

    it('should return correct result if multiple operations are performed and adds/subtracts negative numbers', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.subtract('5');
        calculator.add(-3);
        calculator.add('-4');
        calculator.subtract(-13);
        const result = calculator.get();
        //Assert
        expect(result).equals(1);
    })
})
