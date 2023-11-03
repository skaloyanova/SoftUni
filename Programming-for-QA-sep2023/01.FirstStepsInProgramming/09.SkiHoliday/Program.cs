namespace _09.SkiHoliday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double onePersonRoom = 118.00;
            double apartment = 155.00;
            double presidentApartment = 235.00;

            int days = int.Parse(Console.ReadLine());   //range [0...365]
            string roomType = Console.ReadLine();           //"room for one person", "apartment" or "president apartment"
            string assessment = Console.ReadLine();     //"positive" or "negative"

            double roomPrice = 0;
            double discount = 0;

            switch (roomType)
            {
                case "room for one person":
                    roomPrice = onePersonRoom;
                    break;
                case "apartment":
                    if (days < 10)
                    {
                        discount = 0.3;
                    }
                    else if (days <= 15)
                    {
                        discount = 0.35;
                    } 
                    else
                    {
                        discount = 0.5;
                    }
                    roomPrice = apartment * (1 - discount);
                    break;
                case "president apartment":
                    if (days < 10)
                    {
                        discount = 0.1;
                    }
                    else if (days <= 15)
                    {
                        discount = 0.15;
                    }
                    else
                    {
                        discount = 0.2;
                    }
                    roomPrice = presidentApartment * (1 - discount);
                    break;
            }

            double price = (days - 1) * roomPrice;

            if (assessment == "positive")
            {
                price = price * 1.25;
            }
            else if (assessment == "negative")
            {
                price = price * 0.9;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}