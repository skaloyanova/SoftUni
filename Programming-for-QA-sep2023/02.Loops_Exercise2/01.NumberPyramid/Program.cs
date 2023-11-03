namespace _01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //variant 1
            /**/
            int printNum = 1;
            bool exitLoop = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {                 
                    if (printNum > n)
                    {
                        exitLoop = true;
                        break;
                    }
                    Console.Write(printNum + " ");
                    printNum++;
                }
                if (exitLoop)
                {
                    break;
                }
                Console.WriteLine();
            }
            /**/

            //variant 2
            /*
            int row = 1;
            int col = 1;

            for (int printNum = 1; printNum <= n ; printNum++)
            {
                Console.Write(printNum + " ");
                col++;

                if (col > row)
                {
                    Console.WriteLine();
                    row++;
                    col = 1;
                }
            }
            */
        }
    }
}