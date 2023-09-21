namespace _05.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoneyForVacation = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int daysSpending = 0;
            int days = 0;

            while (true)
            {
                string actionType = Console.ReadLine(); //"spend" and "save"
                double amount = double.Parse(Console.ReadLine());
                days++;

                switch (actionType)
                {
                    case "spend":
                        availableMoney -= amount;
                        if (availableMoney < 0)
                        {
                            availableMoney = 0;
                        }

                        daysSpending++;
                        break;

                    case "save":
                        availableMoney += amount;
                        daysSpending = 0;
                        break;
                }

                if (daysSpending == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    break;
                }

                if (availableMoney >= neededMoneyForVacation)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
            }
        }
    }
}