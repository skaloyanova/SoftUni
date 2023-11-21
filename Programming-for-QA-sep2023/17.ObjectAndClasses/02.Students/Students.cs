namespace _02.Students
{
    internal class Students
    {
        static void Main(string[] args)
        {
            // INPUT: Read information about some students, until you receive the "end" command. After that, you will receive a city name.

            List<Student> studentsList = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] split = input.Split();     //["John", "Smith", "15", "Sofia"]

                Student student = new Student(split[0], split[1], int.Parse(split[2]), split[3]);

                studentsList.Add(student);

                input = Console.ReadLine();
            }

            string city = Console.ReadLine();


            // OUTPUT: Print the students who are from the given city in the following format: "{firstName} {lastName} is {age} years old."
            studentsList
                .Where(s => s.HomeTown == city)
                .ToList()
                .ForEach(s => Console.WriteLine(s));
        }
    }

    /* ALL Classes are in one place, because solutions are tested this way in Judge system */
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }

        // format: "{firstName} {lastName} is {age} years old.
        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}