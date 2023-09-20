namespace _03.NewHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double roses = 5.00;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3.00;
            double gladiolus = 2.50;

            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double cost = 0;

            switch (flowersType)
            {
                case "Roses":
                    cost = flowersCount * roses;
                    if (flowersCount > 80)
                    {
                        cost = cost * 0.9;
                    }
                    break;
                case "Dahlias":
                    cost = flowersCount * dahlias;
                    if (flowersCount > 90)
                    {
                        cost = cost * 0.85;
                    }
                    break;
                case "Tulips":
                    cost = flowersCount * tulips;
                    if (flowersCount > 80)
                    {
                        cost = cost * 0.85;
                    }
                    break;
                case "Narcissus":
                    cost = flowersCount * narcissus;
                    if (flowersCount < 120)
                    {
                        cost = cost * 1.15;
                    }
                    break;
                case "Gladiolus":
                    cost = flowersCount * gladiolus;
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