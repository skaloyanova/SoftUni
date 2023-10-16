/*
 * Read two integer arrays with the same length from the console
 * Prints common elements in two arrays, space-separated
 */

int[] arr1 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

int[] arr2 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

// Sort both arrays
Array.Sort(arr1);
Array.Sort(arr2);

int index1 = 0;
int index2 = 0;

while (index1 < arr1.Length && index2 < arr2.Length)
{
    //Compare array elements.
    //If element from arr1 is smaller that element from arr2, move to the next element in arr1.
    //Do this until you find a match or the element in arr1 is becomes greater that element in arr2.
    //If elements match go to the next element in both arrays.
    //If element in arr1 is greater than element arr2, move to the next element in arr2
    //Do this until you find a match or the element in arr2 is becomes greater that element in arr1.
    //Do this until you compare the last element from arr1 or arr2.

    if (arr1[index1] < arr2[index2])
    {
        index1++;
    }
    else if (arr1[index1] == arr2[index2])
    {
        Console.Write($"{arr1[index1]} ");
        index1++;
        index2++;
    }
    else
    {
        index2++;
    }
}