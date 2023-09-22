namespace _08.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cakeSize = cakeWidth * cakeLength;
            bool stopped = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    stopped = true;
                    break;
                }

                int pieces = int.Parse(input);

                cakeSize -= pieces;

                if (cakeSize < 0)
                {
                    break;
                }
            }

            if (stopped)
            {
                Console.WriteLine($"{cakeSize} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeSize)} pieces more.");
            }
        }
    }
}