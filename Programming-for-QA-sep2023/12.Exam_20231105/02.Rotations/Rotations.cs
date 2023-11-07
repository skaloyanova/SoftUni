List<int> numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

int rotations = int.Parse(Console.ReadLine());

// Remove unnecessary rotations of whole list if number of rotations is larger that the list size
rotations = rotations % numbers.Count;

for (int i = 0; i < rotations; i++)
{
    int lastElement = numbers[numbers.Count - 1];

    numbers.Insert(0, lastElement);
    numbers.RemoveAt(numbers.Count - 1);
}

Console.WriteLine(string.Join(", ", numbers));