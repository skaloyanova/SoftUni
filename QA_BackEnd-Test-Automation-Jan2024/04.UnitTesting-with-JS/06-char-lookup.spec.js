import { lookupChar } from './06-char-lookup.js';
import { expect } from 'chai';

describe('lookupChar(string, index)', () => {
    it('should return undefined if string parameter is not a string (null, NaN, undefined)', () => {
        const result1 = lookupChar(null, 0);
        const result2 = lookupChar(NaN, 0);
        const result3 = lookupChar(undefined, 0);

        expect(result1).undefined;
        expect(result2).undefined;
        expect(result3).undefined;
    })

    it('should return undefined if string parameter is not a string (number, array, boolean, object)', () => {
        const result1 = lookupChar(554, 0);
        const result2 = lookupChar([1, 2], 0);
        const result3 = lookupChar(true, 0);
        const result4 = lookupChar({}, 0);

        expect(result1).undefined;
        expect(result2).undefined;
        expect(result3).undefined;
        expect(result4).undefined;
    })

    it('should return undefined if index parameter is not integer (null, NaN, undefined)', () => {
        const result1 = lookupChar('text', null);
        const result2 = lookupChar('text', NaN);
        const result3 = lookupChar('text', undefined);

        expect(result1).undefined;
        expect(result2).undefined;
        expect(result3).undefined;
    })

    it('should return undefined if index parameter is not integer (decimal number, string, array, boolean, object)', () => {
        const result1 = lookupChar('text', 1.5);
        const result2 = lookupChar('text', '3');
        const result3 = lookupChar('text', [1]);
        const result4 = lookupChar('text', true);
        const result5 = lookupChar('text', {});

        expect(result1).undefined;
        expect(result2).undefined;
        expect(result3).undefined;
        expect(result4).undefined;
        expect(result5).undefined;
    })

    it('should return "Incorrect index" if index parameter is bigger than or equal to the string length', () => {
        const result1 = lookupChar('text', 4);
        const result2 = lookupChar('text', 5);

        expect(result1).equals('Incorrect index');
        expect(result2).equals('Incorrect index');
    })

    it('should return "Incorrect index" if index parameter is a negative number', () => {
        const result = lookupChar('text', -1);

        expect(result).equals('Incorrect index');
    })

    it('should return correct char if valid parameters are given', () => {
        const result = lookupChar('text', 3);

        expect(result).equals('t');
    })

    it('should return "Incorrect index" if empty string is given', () => {
        const result = lookupChar('', 0);

        expect(result).equals('Incorrect index');
    })

    it('should return space if string contains only spaces', () => {
        const result = lookupChar('   ', 0);

        expect(result).equals(' ');
    })
})