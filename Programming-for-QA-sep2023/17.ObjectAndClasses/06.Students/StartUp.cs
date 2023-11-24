namespace _06.Students
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split();

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                students.Add(new Student(firstName, lastName, grade));
            }

            //Sort students by their grade in descending order and Print out the information about each student
            students
                .OrderByDescending(s => s.Grade)
                .ToList()
                .ForEach(s => Console.WriteLine(s));
        }
    }
}