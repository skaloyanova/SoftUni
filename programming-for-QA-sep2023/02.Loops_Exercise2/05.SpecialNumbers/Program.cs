namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //generates all possible "special" numbers from 1111 to 9999. For a number to be "special", N should be divisible by each of its digits without a remainder

            for (int i = 1111; i <= 9999; i++)
            {
                int num = i;
                bool isSpecial = true;

                while (num > 0)
                {
                    int lastDigit = num % 10;
                    num = num / 10;

                    if (lastDigit == 0 || n % lastDigit != 0)   //If a number contains zero as any of its digits, it’s never a special number
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}