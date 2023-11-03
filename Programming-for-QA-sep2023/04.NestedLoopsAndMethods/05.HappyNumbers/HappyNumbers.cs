using System.Text;

namespace _05.HappyNumbers
{
    internal class HappyNumbers
    {
        static void Main(string[] args)
        {
            // INPUT
            // Reads an integer number N from the console
            int n = int.Parse(Console.ReadLine());

            // LOGIC
            // Generate all 4-digit happy numbers {d1}{d2}{d3}{d4} for given integer N (number is happy if d1 + d2 == d3 + d4 == N)
            StringBuilder sb = new StringBuilder();

            for (int d1 = 1; d1 <= 9; d1++)
            {
                if (d1 > n)
                {
                    break;
                }
                for (int d2 = 0; d2 <= 9; d2++)
                {
                    int sum1 = d1 + d2;
                    if (sum1 < n)
                    {
                        continue;
                    }
                    else if (sum1 > n)
                    {
                        break;
                    }

                    for (int d3 = 0; d3 <= 9; d3++)
                    {
                        if (d3 > n)
                        {
                            break;
                        }

                        for (int d4 = 0; d4 <= 9; d4++)
                        {
                            int sum2 = d3 + d4;
                            if (sum2 < n)
                            {
                                continue;
                            }
                            else if (sum2 > n)
                            {
                                break;
                            }

                            sb.Append($"{d1}{d2}{d3}{d4} ");
                        }
                    }
                }
            }

            // OUTPUT
            Console.WriteLine(sb);
        }
    }
}