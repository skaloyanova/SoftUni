/*
 * Reads a text from the console
 * Create a regular expression to match a valid phone number from Sofia
 * A valid number has the following characteristics:
 *    It starts with "+359"
 *    Then, it is followed by the area code (always 2)
 *    After that, it's followed by the number itself:
 *    The number consists of 7 digits (separated into two groups of 3 and 4 digits respectively) 
 *    The different parts are separated by either a space or a hyphen ('-')
 * Print all valid numbers on the console, separated by a comma and a space ", "
 */

using System.Text.RegularExpressions;

string text = Console.ReadLine();

string pattern = @"\+359(?<sep>[\s|-])(2)\<sep>([0-9]{3})\<sep>([0-9]{4})\b";

ICollection<Match> matches = Regex.Matches(text, pattern);

Console.WriteLine(string.Join(", ", matches));

