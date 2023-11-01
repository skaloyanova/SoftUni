/*
 * Reads an integer number from the console
 * Calculate sum of the factorials only on even digits of the given number
 * Print the calculated sum
 * Ex: 4532 -> 4! + 2! = 26
 */

int num = int.Parse(Console.ReadLine());

long sum = 0;

while (num > 0)
{
	int lastDigit = num % 10;
	num = num / 10;

	if (lastDigit % 2 == 0)
	{
		sum += Factorial(lastDigit);
	}
}

Console.WriteLine(sum);


static long Factorial(int n)
{
	if (n == 1)
	{
		return 1;
	}
	
	return n * Factorial(n - 1);
}
