/*
 * Write a program that multiplies the sum of all even digits of a number by the sum of all odd digits of the same number:
 *	Read an integer number from the console
 *	Create a method called GetMultipleOfEvenAndOdds()
 *	Create a method GetSumOfEvenDigits()
 *	Create GetSumOfOddDigits()
 *	You may need to use Math.Abs() for negative numbers
 */

//INPUT
int num = Math.Abs(int.Parse(Console.ReadLine()));


//OUTPUT
Console.WriteLine(getMultipleOfEvenAndOdds(num));


//METHODs
int getMultipleOfEvenAndOdds(int num) {
    return getSumOfEvenDigits(num) * getSumOfOddDigits(num);
}

int getSumOfEvenDigits(int num) {

    int sum = 0;
    while (num > 0)
    {
        int lastDigit = num % 10;
        num = num / 10;

        if (lastDigit % 2 == 0)
        {
            sum += lastDigit;
        }
    }
    return sum;
}
int getSumOfOddDigits(int num) {

    int sum = 0;
    while (num > 0)
    {
        int lastDigit = num % 10;
        num = num / 10;

        if (lastDigit % 2 != 0)
        {
            sum += lastDigit;
        }
    }
    return sum;
}