using System.Text;

int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

int sum = 0;
StringBuilder sb = new StringBuilder();

for (int i = start; i <= end; i++)
{
    sb.Append(i + " ");
    sum += i;
}

sb.AppendLine();
sb.AppendLine("Sum: " + sum);

Console.WriteLine(sb);