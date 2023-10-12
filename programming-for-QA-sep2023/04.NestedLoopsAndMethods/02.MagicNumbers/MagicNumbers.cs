using System.Text;

namespace _02.MagicNumbers
{
    internal class MagicNumbers
    {
        static void Main(string[] args)
        {
            // INPUT
            int num = int.Parse(Console.ReadLine());

            // LOGIC
            // Find all 3-digit magic numbers (product of its digits equals the value of NUM)
            StringBuilder sb = new StringBuilder();

            int n = num;
            if (num < 0)
            {
                n = Math.Abs(num);
            }

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    if (a * b > n)
                    {
                        break;
                    }

                    for (int c = 1; c <= 9; c++)
                    {
                        if (a * b * c == n)
                        {
                            if (num < 0)
                            {
                                sb.Append("-");
                            }
                            sb.Append($"{a}{b}{c} ");
                            break;
                        }
                    }
                }
            }

            // OUTPUT
            Console.WriteLine(sb);
        }
    }
}