/*
 * Reads a text from the console
 * Match full names from the given text
 * A valid full name has the following characteristics:
 *     It consists of two words
 *     Each word starts with a capital letter
 *     After the first letter, it only contains lowercase letters afterward
 *     Each of the two words should be at least two letters long
 *     The two words are separated by a single space
 * Print full names on the console, separated by single space
 */

using System.Text.RegularExpressions;


string text = Console.ReadLine();

string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";

foreach (Match m in Regex.Matches(text, pattern))
{
    Console.Write($"{m} ");
}
