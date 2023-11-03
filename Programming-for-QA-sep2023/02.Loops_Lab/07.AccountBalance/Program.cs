namespace _07.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double accountBalance = 0.0;

            while (input != "NoMoreMoney")
            {
                double depositAmount = double.Parse(input);

                if (depositAmount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {depositAmount:f2}");
                accountBalance += depositAmount;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {accountBalance:f2}");
        }
    }
}