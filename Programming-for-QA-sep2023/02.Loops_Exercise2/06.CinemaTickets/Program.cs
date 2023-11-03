namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Write a program that calculates the percentage of tickets sold for different ticket types: "student", "standard", and "kid". 
             * Calculate the percentage of seats occupied for each movie.
             */

            int studentCount = 0;
            int standardCount = 0;
            int kidCount = 0;
            int totalTicketCount = 0;

            while (true)
            {
                string movieName = Console.ReadLine();              //string
                
                if (movieName == "Finish")
                {
                    break;
                }

                int availSeats = int.Parse(Console.ReadLine());     //integer in the range [1 … 100]
                int movieTicketCount = 0;

                while (availSeats > movieTicketCount)
                {
                    string ticketType = Console.ReadLine();     //"student", "standard", "kid"

                    if (ticketType == "End")
                    {
                        break;
                    }

                    switch (ticketType)
                    {
                        case "student":
                            studentCount++;
                            movieTicketCount++;
                            break;
                        case "standard":
                            standardCount++;
                            movieTicketCount++;
                            break;
                        case "kid":
                            kidCount++;
                            movieTicketCount++;
                            break;
                    }
                }

                totalTicketCount += movieTicketCount;

                double percFull = movieTicketCount * 100.0 / availSeats;
                Console.WriteLine($"{movieName} - {percFull:f2}% full.");
            }

            Console.WriteLine("Total tickets: " + totalTicketCount);
            Console.WriteLine($"{(studentCount * 100.0 / totalTicketCount):f2}% student tickets.");
            Console.WriteLine($"{(standardCount * 100.0 / totalTicketCount):f2}% standard tickets.");
            Console.WriteLine($"{(kidCount * 100.0 / totalTicketCount):f2}% kids tickets.");
        }
    }
}