/*
 * Read a single string from the console
 * Print all the digits on the first line
 * Print all the letters on the second line
 * Print all the other characters on the third line
 * Note: There will always be at least one digit, one letter and one other character.
 */

using System.Text;

string text = Console.ReadLine();

/* VAR 1 */
StringBuilder sbDigits = new StringBuilder();
StringBuilder sbLetters = new StringBuilder();
StringBuilder sbOther = new StringBuilder();

foreach (char c in text)
{
    if (char.IsDigit(c))
    {
        sbDigits.Append(c);
    }
    else if (char.IsLetter(c))
    {
        sbLetters.Append(c);
    }
    else
    {
        sbOther.Append(c);
    }
}

Console.WriteLine(sbDigits);
Console.WriteLine(sbLetters);
Console.WriteLine(sbOther);


/* VAR 2 */
//Console.WriteLine(string.Join("", text.Where(c => char.IsDigit(c)).ToArray()));
//Console.WriteLine(string.Join("", text.Where(c => char.IsLetter(c)).ToArray()));
//Console.WriteLine(string.Join("", text.Where(c => !char.IsLetterOrDigit(c)).ToArray()));