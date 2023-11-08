/*
 * Create a program that takes a text and a string of banned words. 
 * All words included in the ban list should be replaced with a string of asterisks '*', whose length must be equal to the word's length. 
 * The entries in the ban list will be separated by a comma and space ", ". 
 * The ban list should be entered on the first input line and the text on the second input line. 
 * 
 * Example: 
 *      Line1: von Richthofen, German, 80 air
 *      Line2: Manfred Albrecht Freiherr von Richthofen, known in English as Baron von Richthofen was a fighter pilot with the German Air Force during World War I. He is considered the ace-of-aces of the war, being officially credited with 80 air combat victories.
 *      Output: Manfred Albrecht Freiherr **************, known in English as Baron ************** was a fighter pilot with the ****** Air Force during World War I. He is considered the ace-of-aces of the war, being officially credited with ****** combat victories.
 */

string[] banWords = Console.ReadLine().Split(", ");
string text = Console.ReadLine();

foreach (string word in banWords)
{
    text = text.Replace(word, new string('*', word.Length));
}

Console.WriteLine(text);
