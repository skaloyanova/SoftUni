namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double premiere = 12.00;
            double normal = 7.50;
            double discount = 5.00;

            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double ticketPrice = 1;

            switch (type)
            {
                case "Premiere": ticketPrice = premiere; break;
                case "Normal": ticketPrice = normal; break;
                case "Discount": ticketPrice = discount; break;
            }

            double revenue = rows * cols * ticketPrice;

            //Console.WriteLine("{0:f2} leva", revenue);
            Console.WriteLine($"{revenue:f2} leva");
        }
    }
}