/*
 * You are given a program that checks if numbers in a given range [2...N] are prime.
 * For each number is printed "{number} -> {true or false}".
 * The code, however, is not very well written. Your job is to modify it in a way that is easy to read and understand.
 * 
 * int ___Do___ = int.Parse(Console.ReadLine());
 * for (int takoa = 2; takoa <= ___Do___; takoa++)
 * {
 * bool takovalie = true;
 * for (int cepitel = 2; cepitel < takoa; cepitel++)
 * {
 * if (takoa % cepitel == 0)
 * {
 * takovalie = false;
 * break;
 * }
 * }
 * Console.WriteLine("{0} -> {1}", takoa, takovalie); }
 */


int maxNumber = int.Parse(Console.ReadLine());
for (int num = 2; num <= maxNumber; num++)
{
    string isPrime = "true";
    for (int divider = 2; divider < num; divider++)
    {
        if (num % divider == 0)
        {
            isPrime = "false";
            break;
        }
    }
    Console.WriteLine($"{num} -> {isPrime}");
}