/*
 * Reads an integer positive number from the console
 * Print English name of the each digit of a given number on a separate line, starting from the last to the first digit
 */

//VAR 1
/*
int num = int.Parse(Console.ReadLine());

while (num > 0)
{
    int lastDigit = num % 10;
    num /= 10;

    Console.WriteLine(GetDigitAsWord(lastDigit));
}
*/

//VAR 2
string [] output = Console.ReadLine()
    .ToCharArray()
    .Reverse()
    .Select(e => e - '0')
    .Select(e => GetDigitAsWord(e)).ToArray();

Console.WriteLine(string.Join(Environment.NewLine, output));


// Method for converting digit to word for both Variants
static string GetDigitAsWord(int digit)
{
    switch (digit)
    {
        case 1: return "one";
        case 2: return "two";
        case 3: return "three";
        case 4: return "four";
        case 5: return "five";
        case 6: return "six";
        case 7: return "seven";
        case 8: return "eight";
        case 9: return "nine";
        default: return "";
    }
}