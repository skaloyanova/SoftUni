//Input type -> Integer / Floating point / Characters / Boolean / Strings

string input = Console.ReadLine();
string type = "";

while (input != "END")
{
    if (int.TryParse(input, out int value1))
    {
        type = "integer";
    }
    else if (float.TryParse(input, out float value2))
    {
        type = "floating point";
    }
    else if (char.TryParse(input, out char value3))
    {
        type = "character";
    }
    else if (input.ToLower() == "true" || input.ToLower() == "false")
    {
        type = "boolean";
    }
    else
    {
        type = "string";
    }

    Console.WriteLine($"{input} is {type} type");

    input = Console.ReadLine();
}
