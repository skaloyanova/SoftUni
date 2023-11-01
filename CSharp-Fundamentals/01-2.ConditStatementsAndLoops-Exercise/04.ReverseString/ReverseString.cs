using System.Text;

string text = Console.ReadLine();
StringBuilder sb = new StringBuilder();

for (int i = text.Length - 1; i >= 0; i--)
{
    sb.Append(text[i]);
}

Console.WriteLine(sb);