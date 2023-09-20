namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double premierePrice = 12.00;
            double normalPrice = 7.50;
            double discountedPrice = 5.00;

            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double ticketPrice = 1;

            switch (type)
            {
                case "Premiere": ticketPrice = premierePrice; break;
                case "Normal": ticketPrice = normalPrice; break;
                case "Discount": ticketPrice = discountedPrice; break;
            }

            double revenue = rows * cols * ticketPrice;

            //Console.WriteLine("{0:f2} leva", revenue);
            Console.WriteLine($"{revenue:f2} leva");
        }
    }
}