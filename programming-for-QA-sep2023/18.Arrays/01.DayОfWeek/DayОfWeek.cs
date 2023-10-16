int num = int.Parse(Console.ReadLine());

string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

if (num < 1 || num > 7)
{
    Console.WriteLine("Invalid day!");
}
else
{
    Console.WriteLine(days[num - 1]);
}