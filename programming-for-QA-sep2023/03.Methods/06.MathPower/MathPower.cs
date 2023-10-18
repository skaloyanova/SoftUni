//INPUT
int baseNum = int.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());


//OUTPUT
Console.WriteLine(GetMathPow(baseNum, power));


//METHOD
int GetMathPow (int baseN, int pow)
{
	int result = 1;
	for (int i = 0; i < pow; i++)
	{
		result *= baseN;
	}

	return result;
}