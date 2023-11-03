namespace _04.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPoorGrades = int.Parse(Console.ReadLine());

            int poorGradeCount = 0;
            int problemCount = 0;
            string problemName = "";
            int sumOfGrades = 0;

            do
            {
                string input = Console.ReadLine();

                if (input == "Enough")
                {
                    break;
                }

                problemName = input;
                problemCount++;

                int grade = int.Parse(Console.ReadLine());
                sumOfGrades += grade;

                if (grade <= 4)
                {
                    poorGradeCount++;
                }

            } while (poorGradeCount < numPoorGrades);


            if (poorGradeCount == numPoorGrades)
            {
                Console.WriteLine($"You need a break, {numPoorGrades} poor grades.");
            }
            else
            {
                double averageGrade = sumOfGrades * 1.0 / problemCount;
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {problemCount}");
                Console.WriteLine($"Last problem: {problemName}");
            }
        }
    }
}