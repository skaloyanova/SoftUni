using System;

List<int> numbers = new();
int startRange = 1;

while (numbers.Count < 10)
{
	try
	{
		int num = ReadNumber(startRange, 100);
		numbers.Add(num);
		startRange = num;

    }
	catch (ArgumentOutOfRangeException) {
        Console.WriteLine($"Your number is not in range {startRange} - 100!");
    }
	catch (FormatException)
	{
        Console.WriteLine("Invalid Number!");
    }
}

Console.WriteLine(String.Join(", ", numbers));


int ReadNumber(int start, int end)
{
    string input = Console.ReadLine();

	try
	{
		int n = int.Parse(input);
		if (n <= start || n >= end)
        {
			throw new ArgumentOutOfRangeException();
		}
		return n;
	}
	catch (FormatException e)
	{
		throw;
	}
}