try
{
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine(SqrtCalculation(num));
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}


double SqrtCalculation(int num)
{
    if (num < 0)
    {
        throw new ArgumentException("Invalid number.");
    }
    else
    {
        return Math.Sqrt(num);
    }
}