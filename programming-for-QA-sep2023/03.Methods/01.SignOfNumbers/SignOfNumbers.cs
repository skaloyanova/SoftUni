int num = int.Parse(Console.ReadLine());

Console.WriteLine($"The number {num} is {getSign(num)}.");

string getSign(int num)
{
    if (num > 0)
    {
        return "positive";
    }
    else if (num == 0)
    {
        return "zero";
    }
    else
    {
        return "negative";
    }
}