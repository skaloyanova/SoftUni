/*
 * Reads a series of strings from the console, until you receive an "end" command
 * Reverse given strings
 * Print each pair (old text and reversed text) on a separate line in the format: "{word} = {reversed word}"
 */

string word = Console.ReadLine();

while (word != "end")
{
    /* VAR 1 */
    //char[] wordAsArray = word.ToCharArray();
    //string reversedWord = string.Join("", wordAsArray.Reverse());

    /* VAR 2 */
    //string reversedWord = string.Join("", word.ToCharArray().Reverse());

    /* VAR 3 */
    string reversedWord = new string(word.ToCharArray().Reverse().ToArray());

    Console.WriteLine($"{word} = {reversedWord}");

    word = Console.ReadLine();
}
