/*
 * Create a program that receives a single integer.
 * Your task is to find the sum of its digits.
*/

/* VAR 1 */

//int num = int.Parse(Console.ReadLine());
//int sum = 0;

//while (num > 0)
//{
//    sum += num % 10;
//    num /= 10;
//}
//Console.WriteLine(sum);

/* VAR 2 */

string num = Console.ReadLine();
int sum = 0;

foreach (char n in num)
{
    sum += n - 48;  // ASCII "0" = 48
}

Console.WriteLine(sum);
