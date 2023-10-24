/*
 * Reads sequence of integer numbers from the first line of the console
 * Reads an integer number (rotations you have to perform) from the second line of the console
 * Each rotation is when the first element goes at the end
 * Print the resulting sequence
 * Example: Line 1 -> 51 47 32 61 21  // Line 2 -> 2  // Output -> 32 61 21 51 47
 */

/* VAR 1 */

//int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
//int rotations = int.Parse(Console.ReadLine());

//int[] rotatedArray = new int[numbers.Length];

//int firstIndex = rotations % numbers.Length;    //if number of rotations is higher that the array's length
//int length = numbers.Length - firstIndex;

//Array.ConstrainedCopy(numbers, firstIndex, rotatedArray, 0, length);            //copy end of original array to the begining of rotated array 
//Array.ConstrainedCopy(numbers, 0, rotatedArray, length, firstIndex);    //copy beginning of original array to the end of rotated array 

//Console.WriteLine(string.Join(" ", rotatedArray));


/* VAR 2 */

List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int rotations = int.Parse(Console.ReadLine());

rotations = rotations % numbers.Count;      //ignoring multiple rotations of the whole list when rotation number is larger that the list size

for (int i = 0; i < rotations; i++)
{
    numbers.Add(numbers[0]);    //add the first element at the end of the list
    numbers.RemoveAt(0);        //remove first element from the list
}

Console.WriteLine(string.Join(" ", numbers));