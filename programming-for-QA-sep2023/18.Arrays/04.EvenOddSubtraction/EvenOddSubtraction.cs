/*
 * Read an array of integers (from a single line separated with a space)
 * Calculate the difference between the sum of the even and the sum of the odd numbers in an array
 * Print the difference
 */

int[] arrInt = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

int sumEven = 0;
int sumOdd = 0;

foreach (int i in arrInt)
{
	if (i % 2 == 0)
	{
		sumEven += i;
	}
	else
	{
		sumOdd += i;
	}
}

Console.WriteLine(sumEven - sumOdd);