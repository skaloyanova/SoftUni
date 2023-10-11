//INPUT
int baseNum = int.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());


//OUTPUT
Console.WriteLine(getMathPow(baseNum, power));


//METHOD
int getMathPow (int baseN, int pow)
{
	int result = 1;
	for (int i = 0; i < pow; i++)
	{
		result *= baseN;
	}

	return result;
}