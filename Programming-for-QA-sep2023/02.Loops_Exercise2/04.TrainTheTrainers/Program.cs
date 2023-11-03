namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());  //integer in the range [1…20]
            int presentationCount = 0;
            double sumOfAvgGrades = 0;

            while(true)
            {
                string presentationName = Console.ReadLine();

                if (presentationName == "Finish")
                {
                    break;
                }

                double sumOfGrades = 0;

                for (int i = 0; i < juryCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());    //real numbers in the range [2.00…6.00]
                    sumOfGrades += grade;
                }

                double avgGrade = sumOfGrades * 1.0 / juryCount;

                sumOfAvgGrades += avgGrade;
                presentationCount++;

                Console.WriteLine($"{presentationName} - {avgGrade:f2}.");
            }

            Console.WriteLine($"Student's final assessment is {(sumOfAvgGrades / presentationCount):f2}.");

        }
    }
}