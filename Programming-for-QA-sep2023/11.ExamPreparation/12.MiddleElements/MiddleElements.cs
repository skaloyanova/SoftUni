/*
 * Reads an array of integer numbers from the console, separated by single space
 * Array length will always be even number.
 * Calculate the average value of the elements in the middle of the array
 * Print the result formatted to the second digit
 * Ex: 3 4 6 7 8 9 => (6 + 7) / 2 = 6.50
 */

int[] intArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

int midIndex = intArr.Length / 2 - 1;

double average = (intArr[midIndex] + intArr[midIndex + 1]) / 2.0;

Console.WriteLine($"{average:f2}");