/*
 * Reads an array of strings from the console
 * Each string is repeated N times, where N is the length of the string
 * Print the concatenated string
 * Example: Input: hi abc add   // Output: hihiabcabcabcaddaddadd
 */

using System.Text;

string[] words = Console.ReadLine().Split(" ");
StringBuilder output = new StringBuilder();

foreach (string word in words)
{
    for (int i = 0; i < word.Length; i++)
    {
        output.Append(word);
    }
}

Console.WriteLine(output);