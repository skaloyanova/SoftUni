namespace _03.NewHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rosesPrice= 5.00;
            double dahliasPrice = 3.80;
            double tulipsPrice = 2.80;
            double narcissusPrice = 3.00;
            double gladiolusPrice = 2.50;

            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double cost = 0;

            switch (flowersType)
            {
                case "Roses":
                    cost = flowersCount * rosesPrice;
                    if (flowersCount > 80)
                    {
                        cost = cost * 0.9;
                    }
                    break;
                case "Dahlias":
                    cost = flowersCount * dahliasPrice;
                    if (flowersCount > 90)
                    {
                        cost = cost * 0.85;
                    }
                    break;
                case "Tulips":
                    cost = flowersCount * tulipsPrice;
                    if (flowersCount > 80)
                    {
                        cost = cost * 0.85;
                    }
                    break;
                case "Narcissus":
                    cost = flowersCount * narcissusPrice;
                    if (flowersCount < 120)
                    {
                        cost = cost * 1.15;
                    }
                    break;
                case "Gladiolus":
                    cost = flowersCount * gladiolusPrice;
                    if (flowersCount < 80)
                    {
                        cost = cost * 1.2;
                    }
                    break;
            }

            double diff = budget - cost;

            if (diff >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowersType} and {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(diff):f2} leva more.");
            }

        }
    }
}