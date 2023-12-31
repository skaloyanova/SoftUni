﻿//INPUT
using System.Text;

string text = Console.ReadLine();
int repeatCount = int.Parse(Console.ReadLine());

//OUTPUT
Console.WriteLine(RepeatText(text, repeatCount));


//METHOD
string RepeatText (string text, int count)
{
	StringBuilder sb = new StringBuilder();
	for (int i = 0; i < count; i++)
	{
		sb.Append(text);
	}
	return sb.ToString();
}