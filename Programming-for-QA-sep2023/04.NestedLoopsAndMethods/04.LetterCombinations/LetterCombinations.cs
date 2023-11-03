using System.Text;

namespace _04.LetterCombinations
{
    internal class LetterCombinations
    {
        static void Main(string[] args)
        {
            // INPUT
            // Read a start letter s, end letter e and excluded letter x
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char excluded = char.Parse(Console.ReadLine());

            // LOGIC
            // Generate all combinations of 3 letters in the range [s…e], excluding x
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int letter1 = start; letter1 <= end; letter1++)
            {
                if (letter1 == excluded)
                {
                    continue;
                }

                for (int letter2 = start; letter2 <= end; letter2++)
                {
                    if (letter2 == excluded)
                    {
                        continue;
                    }

                    for (int letter3 = start; letter3 <= end; letter3++)
                    {
                        if (letter3 == excluded)
                        {
                            continue;
                        }

                        sb.Append($"{(char)letter1}{(char)letter2}{(char)letter3} ");
                        count++;
                    }
                }
            }

            // OUTPUT
            Console.WriteLine(sb);
            Console.WriteLine(count);
        }
    }
}