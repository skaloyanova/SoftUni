/*
 * Reads an integer number N from the console, always greater than 1
 * Print all magic numbers in range [1; N] - separated by single space
 * The number is magic when:
 *      All of its digits are prime numbers
 *      Sum of all digits is divisible by 2
 * If there are no such numbers print "no"
 */

int n = int.Parse(Console.ReadLine());

string output = "";

for (int num = 1; num <= n; num++)
{
    if (IsMagicNumber(num))
    {
        output += num + " ";
    }
}

output = output.Trim();

if (output == "")
{
    Console.WriteLine("no");
}
else
{
    Console.WriteLine(output);
}


static bool IsPrime(int n)
{
    if (n <= 1)
    {
        return false;
    }

    for (int i = 2; i < n; i++)
    {
        if (n % i == 0)
        {
            return false;
        }
    }

    return true;
}

static bool IsDivisibleByTwo (int n)
{
    return n % 2 == 0;
}

static bool IsMagicNumber (int n)
{
    int sum = 0;

    while (n > 0)
    {
        int lastDigit = n % 10;
        n = n / 10;

        if (IsPrime(lastDigit) == false)
        {
            return false;
        }

        sum += lastDigit;
    }

    if (sum % 2 != 0)
    {
        return false;
    }

    return true;
}