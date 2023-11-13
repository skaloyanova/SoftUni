/*
 * Reads a text from the console
 * Create a regular expression to match a valid dates
 * Every valid date has the following characteristics:
 *    Format: "dd{separator}MMM{separator}yyyy"
 *    Always starts with two digits, followed by a separator
 *    After that, it has one uppercase and two lowercase letters (e.g. Jan, Mar)
 *    After that, it has a separator and exactly 4 digits (for the year)
 *    The separator could be either of three things: a period ('.'), a hyphen ('-') or a forward-slash ('/')
 *    The separator needs to be the same for the whole date (e.g. 13.03.2016 is valid, 13.03/2016 is NOT). Use a group backreference to check for this
 * Use named capturing groups in your regular expression.
 * Print all valid dates on the console, separated by a new line
 */

using System.Text.RegularExpressions;

string text = Console.ReadLine();

string pattern = @"(\b?<day>[0-9]{2})(?<sep>[\./-])(?<month>[A-Z][a-z]{2})\<sep>(?<year>[0-9]{4})\b";

MatchCollection matches = Regex.Matches(text, pattern);

foreach (Match match in matches)
{
    Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
}
