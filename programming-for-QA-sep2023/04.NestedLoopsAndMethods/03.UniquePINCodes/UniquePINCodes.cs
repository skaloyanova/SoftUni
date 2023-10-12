namespace _03.UniquePINCodes
{
    internal class UniquePINCodes
    {
        static void Main(string[] args)
        {
            // INPUT
            // Read 3 integer digits: max1, max2, max3 (each is an upper limit)
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());
            int max3 = int.Parse(Console.ReadLine());

            // LOGIC + OUTPUT
            /* Generate unique 3-digit PIN codes, matching the following:
             *   Each digit is within the following range: 
             *   First digit: [1 … max1]
             *   Second digit: [1 … max2]
             *   Third digit: [1 … max3]
             *   The first and the third digit must be even
             *   The second digit must be a prime number in the range [2…7]
             */

            for (int first = 2; first <= max1; first += 2)
            {
                for (int second = 1; second <= max2; second++)
                {
                    if (second != 2 && second != 3 && second != 5 && second != 7)
                    {
                        continue;
                    }

                    for (int third = 2; third <= max3; third += 2)
                    {
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}