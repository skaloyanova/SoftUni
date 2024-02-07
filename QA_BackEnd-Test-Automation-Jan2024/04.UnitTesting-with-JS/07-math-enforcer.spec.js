import { mathEnforcer } from './07-math-enforcer.js';
import { expect } from 'chai';

describe('mathEnforcer', () => {
    describe('addFive(num) function', () => {
        it('should return "undefined" if parametar is not a number (null, undefined)', () => {
            const result1 = mathEnforcer.addFive(null);
            const result2 = mathEnforcer.addFive(undefined);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
        })

        it('should return "undefined" if parametar is not a number (string, array, object, boolean)', () => {
            const result1 = mathEnforcer.addFive('10');
            const result2 = mathEnforcer.addFive([10]);
            const result3 = mathEnforcer.addFive({});
            const result4 = mathEnforcer.addFive(true);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
            expect(result3).to.be.undefined;
            expect(result4).to.be.undefined;
        })

        it('should return correct result if valid parametar is given (integer number)', () => {
            const result = mathEnforcer.addFive(12);

            expect(result).equals(17);
        })

        it('should return correct result if valid parametar is given (floating point number)', () => {
            const result = mathEnforcer.addFive(12.5745);

            expect(result).equals(17.5745);
        })

        it('should return correct result if valid parametar is given (negative number)', () => {
            const result = mathEnforcer.addFive(-6.5);

            expect(result).equals(-1.5);
        })
    })

    describe('subtractTen(num) function', () => {
        it('should return "undefined" if parametar is not a number (null, undefined)', () => {
            const result1 = mathEnforcer.subtractTen(null);
            const result2 = mathEnforcer.subtractTen(undefined);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
        })
        it('should return "undefined" if parametar is not a number (string, array, object, boolean)', () => {
            const result1 = mathEnforcer.subtractTen('10');
            const result2 = mathEnforcer.subtractTen([10]);
            const result3 = mathEnforcer.subtractTen({});
            const result4 = mathEnforcer.subtractTen(true);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
            expect(result3).to.be.undefined;
            expect(result4).to.be.undefined;
        })

        it('should return correct result if valid parametar is given (integer number)', () => {
            const result = mathEnforcer.subtractTen(22);

            expect(result).equals(12);
        })

        it('should return correct result if valid parametar is given (floating point number)', () => {
            const result = mathEnforcer.subtractTen(20.123456);

            expect(result).closeTo(10.123456, 0.01);
        })

        it('should return correct result if valid parametar is given (negative number)', () => {
            const result = mathEnforcer.subtractTen(-5.55);

            expect(result).equals(-15.55);
        })
    })

    describe('sum(num1, num2) function', () => {
        it('should return "undefined" if parametar 1 is not a number (null, undefined)', () => {
            const result1 = mathEnforcer.sum(null, 5);
            const result2 = mathEnforcer.sum(undefined, 5);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
        })
        it('should return "undefined" if parametar 1 is not a number (string, array, object, boolean)', () => {
            const result1 = mathEnforcer.sum('10', 5);
            const result2 = mathEnforcer.sum([10], 5);
            const result3 = mathEnforcer.sum({}, 5);
            const result4 = mathEnforcer.sum(true, 5);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
            expect(result3).to.be.undefined;
            expect(result4).to.be.undefined;
        })

        it('should return "undefined" if parametar 2 is not a number (null, NaN, undefined)', () => {
            const result1 = mathEnforcer.sum(5, null);
            const result2 = mathEnforcer.sum(5, undefined);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
        })
        it('should return "undefined" if parametar 2 is not a number (string, array, object, boolean)', () => {
            const result1 = mathEnforcer.sum(5, '10');
            const result2 = mathEnforcer.sum(5, [10]);
            const result3 = mathEnforcer.sum(5, {});
            const result4 = mathEnforcer.sum(5, true);

            expect(result1).to.be.undefined;
            expect(result2).to.be.undefined;
            expect(result3).to.be.undefined;
            expect(result4).to.be.undefined;
        })

        it('should return correct result if valid parametars is given (integer numbers)', () => {
            expect(mathEnforcer.sum(5, 12344)).equals(12349);
        })

        it('should return correct result if valid parametar is given (floating point numbers)', () => {
            expect(mathEnforcer.sum(5.48, 3.75569)).equals(9.23569);
        })

        it('should return correct result if valid parametar is given (negative numbers)', () => {
            expect(mathEnforcer.sum(-5, 15)).equals(10);
            expect(mathEnforcer.sum(-5, -15)).equals(-20);
        })
    })
})