/*
 * Reads an array of integer numbers from the first line of the console, separated by single space
 * Read an integer number N from the second line of the console
 * Find average value of the last N elements in the array
 * Print the average value formatted to the second decimal digit
 * 
 * Example -> Line1: 3 42 61 7 8 9 10 23  // Line2: 4  // output: 12.50
 */

// VAR 1
/*
List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int n = int.Parse(Console.ReadLine());

numbers.Reverse();

double sum = 0;

for (int i = 0; i < n; i++)
{
    sum += numbers[i];
}

Console.WriteLine($"{(sum / n):f2}");
*/

// VAR 2
double average = Console.ReadLine()
    .Split(" ")
    .Reverse()
    .Take(int.Parse(Console.ReadLine()))
    .Select(int.Parse)
    .Average();

Console.WriteLine($"{average:f2}");

