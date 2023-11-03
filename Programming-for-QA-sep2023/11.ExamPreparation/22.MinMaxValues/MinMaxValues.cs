/*
 * Reads an array of integer numbers from the first line of the console, separated by single space
 * Read an integer number N from the second line of the console
 * Find max number in the first N elements in the given array
 * Find min number in the first N elements in the given array
 * Print max number and min number, each on separate line
 */

int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

int n = int.Parse(Console.ReadLine() ?? "");

if (n > numbers.Length)
{
    n = numbers.Length;
}

int max = int.MinValue;
int min = int.MaxValue;

for (int i = 0; i < n; i++)
{
    max = Math.Max(max, numbers[i]);
    min = Math.Min(min, numbers[i]);
}

Console.WriteLine(max);
Console.WriteLine(min);