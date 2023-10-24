/*
 * Reads sequence of integer numbers from the first line of the console
 * Find all the top integers in a sequence
 * Top integer is an integer that is bigger than all the elements to its right
 */

int[] sequence = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

List<int> topIntegers = new List<int>
{
    sequence.Last()    //last number in the sequence is always Top integer
};

for (int i = sequence.Length - 1; i > 0; i--)
{
    int num = sequence[i];
    int prevNum = sequence[i - 1];

    if (prevNum > num && prevNum > topIntegers.Last())
    {
        topIntegers.Add(prevNum);
    }
}

topIntegers.Reverse();
Console.WriteLine(string.Join(" ", topIntegers));