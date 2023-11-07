//Variant 1
/*
int studentsCount = int.Parse(Console.ReadLine());

double sum = 0;

for (int i = 0; i < studentsCount; i++)
{
    double grade = double.Parse(Console.ReadLine());

    sum += grade;
}

double averageGrade = sum / studentsCount;

Console.WriteLine($"{averageGrade:f2}");
*/

//Variant 2
int studentsCount = int.Parse(Console.ReadLine());
List<double> grades = new();

while(studentsCount > 0)
{
    grades.Add(double.Parse(Console.ReadLine()));

    studentsCount--;
}

Console.WriteLine($"{grades.Average():f2}");