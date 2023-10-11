double grade = double.Parse(Console.ReadLine());

Console.WriteLine(getGradeLabel(grade));

string getGradeLabel (double grade)
{
    if (grade >= 2 && grade <= 2.99)
    {
        return "Fail";
    }
    else if (grade >= 3 && grade <= 3.49)
    {
        return "Average";
    }
    else if (grade >= 3.5 && grade <= 4.49)
    {
        return "Good";
    }
    else if (grade >= 4.5 && grade <= 5.49)
    {
        return "Very good";
    }
    else if (grade >= 5.5 && grade <= 6)
    {
        return "Excellent";
    }
    else
    {
        return "";
    }
}