namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());   //range [10.00...5000.00]
            string season = Console.ReadLine();                 //"summer" or "winter"

            string destination = "";    //"Bulgaria", "Balkans" and "Europe"
            string holidayType = "";    //"Camp" and "Hotel"

            double cost = 0.00;

            // Determine holidayType
            if (season == "summer")
            {
                holidayType = "Camp";
            }
            else if (season == "winter")
            {
                holidayType = "Hotel";
            }

            //Determine destination
            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer": cost = budget * 0.3; break;
                    case "winter": cost = budget * 0.7; break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer": cost = budget * 0.4; break;
                    case "winter": cost = budget * 0.8; break;
                }
            }
            else
            {
                destination = "Europe";
                cost = budget * 0.9;
                holidayType = "Hotel";
            }


            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayType} - {cost:f2}");
        }
    }
}