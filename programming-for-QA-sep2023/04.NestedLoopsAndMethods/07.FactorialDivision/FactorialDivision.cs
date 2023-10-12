namespace _07.FactorialDivision
{
    internal class FactorialDivision
    {
        static void Main(string[] args)
        {
            // INPUT - Read two integers numbers from the console
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            // LOGIC - Divide the first calculated factorial by the second calculated factorial
            if (n1 < 0 || n2 < 0)
            {
                return;
            }
            double division = getFactorial(n1) * 1.0 / getFactorial(n2);

            // OUTPUT - Print the result of the division
            Console.WriteLine(division);
        }

        // METHOD
        static int getFactorial(int n)
        {
            int fact = 1;

            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }

            return fact;

            /* using recursion 
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * getFactorial(n - 1);
            }
            */
        }
    }
}