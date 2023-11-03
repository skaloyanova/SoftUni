/*
 * Reads an integer number from the console
 * Calculate sum of the factorials only on even digits of the given number
 * Print the calculated sum
 * Ex: 4532 -> 4! + 2! = 26
 */


// VAR 1
/*
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
*/

// VAR 2
long result = Console.ReadLine()
	.ToCharArray()
	.Select(c => c - '0')
	.Where(c => c % 2 == 0)
	.Select(c => Factorial(c))
	.Sum();

Console.WriteLine(result);


// Method for calculating Factorial
static long Factorial(int n)
{
    if (n == 1)
    {
        return 1;
    }

    return n * Factorial(n - 1);
}