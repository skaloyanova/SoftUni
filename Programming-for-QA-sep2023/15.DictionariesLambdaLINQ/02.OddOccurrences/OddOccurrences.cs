/*
 * Write a program that extracts all elements from a given sequence of words that are present in it an odd number of times (case-insensitive):
 *   Words are given on a single line, space-separated.
 *   Print the result elements in lowercase, in their order of appearance.
 */

string[] words = Console.ReadLine().Split().Select(e => e.ToLower()).ToArray();

// Fill in the Dictionary with the words and their occurrences
Dictionary<string, int> wordsCount = new();

foreach (string word in words)
{
	if (wordsCount.ContainsKey(word))
	{
		wordsCount[word] += 1;
	}
	else
	{
		wordsCount[word] = 1;
	}
}

// Filter Dictionary and leave only words with odd number of occurrences
wordsCount = wordsCount.Where(e => e.Value % 2 != 0).ToDictionary(e => e.Key, e => e.Value);

// Output
Console.WriteLine(string.Join(" ", wordsCount.Select(e => e.Key)));


