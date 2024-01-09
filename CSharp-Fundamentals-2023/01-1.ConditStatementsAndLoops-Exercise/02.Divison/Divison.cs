int num = int.Parse(Console.ReadLine());

string output = "Not divisible";

if (num % 10 == 0)
    output = "The number is divisible by 10";
else if (num % 7 == 0)
    output = "The number is divisible by 7";
else if (num % 6 == 0)
    output = "The number is divisible by 6";
else if (num % 3 == 0)
    output = "The number is divisible by 3";
else if (num % 2 == 0)
    output = "The number is divisible by 2";

Console.WriteLine(output);