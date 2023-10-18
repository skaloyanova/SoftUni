/*
 * Printing Triangle - Example:
 * 1
 * 1 2
 * 1 2 3 
 * 1 2 
 * 1
 */


using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());


        // VAR 1 - Printing top and bottom part in separate loops
        /*
        // Printing top part
        for (int i = 1; i <= n - 1; i++)
        {
            PrintRow(i);
        }

        // Printing bottom part
        for (int i = n; i >= 1; i--)
        {
            PrintRow(i);
        }
        */


        // VAR 2 - Print top and bottom in one loop

        bool isBottomPart = false;
        for (int i = 1; i <= 2 * n - 1 && i > 0;)
        {
            PrintRow(i);

            if (i == n)
            {
                isBottomPart = true;
            }

            if (isBottomPart)
            {
                i--;
            }
            else
            {
                i++;
            }

        }


        // Method for ptinting 1 row
        void PrintRow(int n)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                sb.Append(i + " ");
            }

            Console.WriteLine(sb);
        }
    }
}