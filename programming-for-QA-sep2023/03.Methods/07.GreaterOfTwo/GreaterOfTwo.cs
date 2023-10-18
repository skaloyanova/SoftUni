//INPUT
string type = Console.ReadLine();   //"int", "char" or "string"
string a = Console.ReadLine();
string b = Console.ReadLine();


//OUTPUT
Console.WriteLine(GetBiggest(type, a, b));

//METHODs
string GetBiggest (string type, string a, string b)
{
    switch (type)
    {
        case "int":
            return GetBiggestInt(int.Parse(a), int.Parse(b)).ToString();
            break;
        case "char":
            return GetBiggestChar(char.Parse(a), char.Parse(b)).ToString();
            break;
        case "string":
            return GetBiggestString(a, b);
            break;
        default: return ""; break;
    }
}
int GetBiggestInt (int a, int b)
{
	if (a > b)
	{
		return a;
	}
	else
	{
		return b;
	}
}

char GetBiggestChar (char a, char b)
{
    if (a > b)
    {
        return a;
    }
    else
    {
        return b;
    }
}

string GetBiggestString(string a, string b)
{
    if (a.CompareTo(b) > 0)
    {
        return a;
    }
    else
    {
        return b;
    }
}