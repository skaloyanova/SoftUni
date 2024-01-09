int n = int.Parse(Console.ReadLine());

char endLetter = (char)('a' + n - 1);

for (char c1 = 'a'; c1 <= endLetter; c1++)
{
	for (char c2 = 'a'; c2 <= endLetter; c2++)
	{
		for (char c3 = 'a'; c3 <= endLetter; c3++)
		{
			Console.WriteLine($"{(char)c1}{(char)c2}{(char)c3}");
		}
	}
}
