import { rgbToHexColor } from './03-rgb-to-hex.js';
import { expect } from 'chai'

describe('rgbToHexColor(red, green, blue)', () => {
    it('should return hex color if valid "red", "green" and "blue" parameters are given', () => {
        //Act
        const result1 = rgbToHexColor(0, 0, 0);
        const result2 = rgbToHexColor(255, 255, 255);
        const result3 = rgbToHexColor(100, 100, 100);
        //Assert
        expect(result1).to.equal('#000000');
        expect(result2).to.equal('#FFFFFF');
        expect(result3).to.equal('#646464');
    })

    it('should return undefined if invalid "red" parameter is given', () => {
        //Act
        const nonIntegerRedResult = rgbToHexColor(12.5, 100, 100);
        const nonNumericRedResult = rgbToHexColor('12', 100, 100);
        const lessThanZeroRedResult = rgbToHexColor(-1, 100, 100);
        const higherThan255RedResult = rgbToHexColor(256, 100, 100);
        //Assert
        expect(nonIntegerRedResult).to.be.undefined;
        expect(nonNumericRedResult).to.be.undefined;
        expect(lessThanZeroRedResult).to.be.undefined;
        expect(higherThan255RedResult).to.be.undefined;
    })

    it('should return undefined if invalid "green" parameter is given', () => {
        const nonIntegerGreenResult = rgbToHexColor(0, 100.2, 100);
        const nonNumericGreenResult = rgbToHexColor(0, '100', 100);
        const lessThanZeroGreenResult = rgbToHexColor(0, -1, 100);
        const higherThan255GreenResult = rgbToHexColor(0, 256, 100);
        //Assert
        expect(nonIntegerGreenResult).to.be.undefined;
        expect(nonNumericGreenResult).to.be.undefined;
        expect(lessThanZeroGreenResult).to.be.undefined;
        expect(higherThan255GreenResult).to.be.undefined;
    })

    it('should return undefined if invalid "blu" parameter is given', () => {
        const nonIntegerBlueResult = rgbToHexColor(0, 255, 100.123);
        const nonNumericBlueResult = rgbToHexColor(0, 255, "100");
        const lessThanZeroBlueResult = rgbToHexColor(0, 255, -1);
        const higherThan255BlueResult = rgbToHexColor(0, 255, 256);
        //Assert
        expect(nonIntegerBlueResult).to.be.undefined;
        expect(nonNumericBlueResult).to.be.undefined;
        expect(lessThanZeroBlueResult).to.be.undefined;
        expect(higherThan255BlueResult).to.be.undefined;
    })
})