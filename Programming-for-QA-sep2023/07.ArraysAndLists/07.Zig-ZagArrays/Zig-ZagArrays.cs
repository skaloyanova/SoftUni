/*
 * Creates two empty integer arrays
 * Reads an integer number N from the console
 * Reads two integer numbers on the next N lines 
 * Form two integer arrays as shown in the example below
 * Input:
 * 4
 * 1 5
 * 9 10
 * 31 81
 * 41 20
 * Output: 
 * 1 10 31 20
 * 5 9 81 41
 */

int n = int.Parse(Console.ReadLine());

int[] arr1 = new int[n];
int[] arr2 = new int[n];

for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    if (i % 2 == 0)
    {
        arr1[i] = input[0];
        arr2[i] = input[1];
    }
    else
    {
        arr1[i] = input[1];
        arr2[i] = input[0];
    }
}

Console.WriteLine(string.Join(" ", arr1));
Console.WriteLine(string.Join(" ", arr2));