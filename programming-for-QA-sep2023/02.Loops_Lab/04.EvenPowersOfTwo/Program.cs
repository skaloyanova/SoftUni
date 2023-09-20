namespace _04.EvenPowersOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            /*
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(Math.Pow(2, i));
            }
            */

            for (int i = 0; i <= n; i += 2)
            {
                int num = 1;
                for (int j = 0; j < i; j++)
                {
                    num *= 2;
                }
                Console.WriteLine(num);
            }
        }
    }
}