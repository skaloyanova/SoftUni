/*
 * Reads sequence of integer numbers from the first line of the console
 * Find the longest sequence of equal elements in a sequence of integers
 * Note: If several longest sequences exist, print the leftmost one.
 */

int[] sequence = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

int index = 0;
int length = 1;

int[] indexAndLength = {index, length};     //here I will keep the first index of sequence [0] and the length of it [1]

for (int i = 0; i < sequence.Length - 1; i++)
{
    if (sequence[i] == sequence[i + 1])
    {
        length++;

        if (length > indexAndLength[1])   //the case where the last 2 compared elements are equal
        {
            indexAndLength[0] = index;
            indexAndLength[1] = length;
        }
    }
    else
    {
        index = i + 1;  //reset index, i.e. moving to next element
        length = 1;     //reset length
    }
}

// OUTPUT
int startIndex = indexAndLength[0];
int endIndex = indexAndLength[0] + indexAndLength[1] - 1;

for (int i = startIndex; i <= endIndex; i++)
{
    Console.Write(sequence[i] + " ");
}