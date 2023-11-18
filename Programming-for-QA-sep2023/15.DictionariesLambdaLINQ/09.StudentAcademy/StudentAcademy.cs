/*
 * You will receive n pair of rows. First, you will receive the student's name, after that, you will receive their grade.
 * Check if the student already exists and if not, add him.
 * Keep track of all grades for each student.
 * When you finish reading the data, keep the students with an average grade higher than or equal to 4.50.
 */

int n = int.Parse(Console.ReadLine());

Dictionary<string, List<double>> students = new();

// Fill in the dictionary with data

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    double grade = double.Parse(Console.ReadLine());

    if (!students.ContainsKey(name))
    {
        students.Add(name, new List<double>());
    }

    students[name].Add(grade);
}

students = students.Where(e => e.Value.Average() >= 4.50).ToDictionary(e => e.Key, e => e.Value);

/* OUTPUT
 * Print the students and their average grade in the following format: "{name} –> {averageGrade}"
 * Format the average grade to the 2nd decimal place.
 */

students
    .Select(e => $"{e.Key} -> {e.Value.Average():f2}")
    .ToList()
    .ForEach(e => Console.WriteLine(e));