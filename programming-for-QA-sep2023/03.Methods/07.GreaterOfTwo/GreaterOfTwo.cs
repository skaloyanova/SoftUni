//INPUT
string type = Console.ReadLine();   //"int", "char" or "string"
string a = Console.ReadLine();
string b = Console.ReadLine();


//OUTPUT
Console.WriteLine(getBiggest(type, a, b));

//METHODs
string getBiggest (string type, string a, string b)
{
    switch (type)
    {
        case "int":
            return getBiggestInt(int.Parse(a), int.Parse(b)).ToString();
            break;
        case "char":
            return getBiggestChar(char.Parse(a), char.Parse(b)).ToString();
            break;
        case "string":
            return getBiggestString(a, b);
            break;
        default: return ""; break;
    }
}
int getBiggestInt (int a, int b)
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

char getBiggestChar (char a, char b)
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

string getBiggestString(string a, string b)
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