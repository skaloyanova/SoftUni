namespace _02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            int sumOfAllNumbers = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                maxNumber = Math.Max(maxNumber, currentNum);
                sumOfAllNumbers += currentNum;
            }

            int sumOfTheRestNumbers = sumOfAllNumbers - maxNumber;

            if (sumOfTheRestNumbers == maxNumber)
            {
                Console.WriteLine($"Yes\nSum = {maxNumber}");
            }
            else
            {
                Console.WriteLine($"No\nDiff = {Math.Abs(sumOfTheRestNumbers - maxNumber)}");
            }
        }
    }
}