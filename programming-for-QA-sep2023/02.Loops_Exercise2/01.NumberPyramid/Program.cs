namespace _01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

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
        }
    }
}