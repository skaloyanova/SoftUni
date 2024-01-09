using System.Text;

int n = int.Parse(Console.ReadLine());

StringBuilder sb = new StringBuilder();

for (int row = 1; row <= n; row++)
{
	for (int col = 0; col < row; col++)
	{
		sb.Append(row + " ");
	}
	sb.AppendLine();
}

Console.WriteLine(sb);