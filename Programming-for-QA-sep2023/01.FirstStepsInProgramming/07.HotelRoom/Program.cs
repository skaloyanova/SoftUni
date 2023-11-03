namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();  // "May", "June", "July", "August", "September" or "October"
            int nights = int.Parse(Console.ReadLine());     // range [1 ... 200]

            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            // Set the Studio and Apartment prices
            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;
                    if (nights > 14)
                    {
                        studioPrice *= 0.7;
                    }
                    else if (nights > 7)
                    {
                        studioPrice *= 0.95;
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 75.20;
                    apartmentPrice = 68.70;
                    if (nights > 14)
                    {
                        studioPrice *= 0.8;
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    break;
            }

            if (nights > 14)
            {
                apartmentPrice *= 0.9;
            }

            Console.WriteLine($"Apartment: {apartmentPrice * nights:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice * nights:f2} lv.");
        }
    }
}