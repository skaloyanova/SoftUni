// Your task is to calculate the sum of all valid integer numbers in the input. 

string[] input = Console.ReadLine().Split();
int sum = 0;

foreach (string element in input)
{
    try
    {
        sum += int.Parse(element);
    }
    catch (FormatException)         //not in the correct format, t.e. char/string
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch (OverflowException)       //out of the integer type range
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");