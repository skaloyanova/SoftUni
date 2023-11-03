using System.Collections.Generic;
using System.Text;

namespace _01.StupidPasswords
{
    internal class StupidPasswords
    {
        static void Main(string[] args)
        {
            // INPUT
               int n = int.Parse(Console.ReadLine());

            // LOGIC
            // Generates all possible passwords consisting of the following 3 parts:
            //  The first part is an even number in the range[2…N]
            //  The second digit is an odd number in the range[1…N]
            //  The third is the product of the first two

            StringBuilder sb = new StringBuilder();
            for (int first = 2; first <= n; first += 2)
            {
                for (int second = 1; second <= n; second += 2)
                {
                    sb.Append($"{first}{second}{first * second} ");
                }
            }

            // OUTPUT
            Console.WriteLine(sb);
        }
    }
}