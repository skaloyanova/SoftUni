namespace _08.TheGreatestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                int number = int.Parse(input);

                max = Math.Max(max, number);

                input = Console.ReadLine();
            }

            Console.WriteLine(max);
        }
    }
}