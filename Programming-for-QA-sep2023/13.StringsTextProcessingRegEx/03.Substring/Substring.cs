/*
 * Read first string from the first line of the console
 * Reads second string from the second line of the console
 * Remove all of the occurrences of the first string in the second string
 * Print the remaining string
 * Example: Line1 - ice // Line2 - kicegiciceeb // Output - kgb
 */

string strToRemove = Console.ReadLine();
string text = Console.ReadLine();

int length = strToRemove.Length;

while (text.Contains(strToRemove))
{
    /* VAR 1 */
    //int index = text.IndexOf(strToRemove);
    //text = text.Remove(index, length);

    /* VAR 2 */
    text = text.Replace(strToRemove, "");

}

Console.WriteLine(text);