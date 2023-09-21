namespace _10.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            int grade = 1;
            double annualStudentGrade = double.Parse(Console.ReadLine());
            
            double sumOfSudentGrades = annualStudentGrade;

            while (annualStudentGrade >= 4.00 && grade < 12)
            {
                grade++;
                annualStudentGrade = double.Parse(Console.ReadLine());

                sumOfSudentGrades += annualStudentGrade;                
            }

            double avgSudentGrade = sumOfSudentGrades * 1.0 / grade;

            if (annualStudentGrade < 4.00)
            {
                Console.WriteLine($"{studentName} has been excluded at {grade} grade");
            }
            else
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {avgSudentGrade:f2}");
            }

        }
    }
}