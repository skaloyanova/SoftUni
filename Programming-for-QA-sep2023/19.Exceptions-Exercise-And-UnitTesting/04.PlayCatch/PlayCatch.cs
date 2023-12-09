using System.Text;

int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int errorCounter = 0;

while (errorCounter < 3)
{
    string[] command = Console.ReadLine().Split();
    string action = command[0];

    try
    {
        switch (action)
        {
            case "Replace":

                int index = int.Parse(command[1]);
                int element = int.Parse(command[2]);
                numbers[index] = element;

                break;
            case "Print":
                int startIndex = int.Parse(command[1]);
                int endIndex = int.Parse(command[2]);

                List<int> print = new();
                for (int i = startIndex; i <= endIndex; i++)
                {
                    print.Add(numbers[i]);
                }

                Console.WriteLine(String.Join(", ", print));

                break;
            case "Show":
                int idx = int.Parse(command[1]);
                Console.WriteLine(numbers[idx]);
                break;
        }
    }
    catch (IndexOutOfRangeException)
    {
        errorCounter++;
        Console.WriteLine("The index does not exist!");
    }
    catch (FormatException)
    {
        errorCounter++;
        Console.WriteLine("The variable is not in the correct format!");
    }
}

Console.WriteLine(String.Join(", ", numbers));