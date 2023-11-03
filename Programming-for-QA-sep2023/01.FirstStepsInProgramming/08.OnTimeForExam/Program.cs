namespace _08.OnTimeForExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinute;
            int arrivalTime = arrivalHour * 60 + arrivalMinute;

            int diff = examTime - arrivalTime;

            string status = "";
            string beforeAfter = "";
            string time = "";

            if (diff > 30)
            {
                status = "Early";
                beforeAfter = "before";
            }
            else if (diff >= 0)
            {
                status = "On time";
                beforeAfter = "before";
            }
            else
            {
                status = "Late";
                beforeAfter = "after";
            }


            if (Math.Abs(diff) < 60)
            {
                time = String.Format($"{Math.Abs(diff)} minutes");
            }
            else
            {
                int hh = Math.Abs(diff) / 60;
                int mm = Math.Abs(diff) % 60;
                time = String.Format($"{hh}:{mm:d2} hours");
            }


            Console.WriteLine(status);
            if (diff != 0)
            {
                Console.WriteLine($"{time} {beforeAfter} the start");
            }

        }
    }
}