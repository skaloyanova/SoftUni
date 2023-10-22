/*
 * Reads two sequences with integer numbers from the console
 * Create a result list that contains the numbers from both of the sequences
 * The first element should be from the first sequence, the second from the second sequence, and so on
 * If the length of the two sequences is not equal, just add the remaining elements at the end of the sequence
 */

/* VAR 1 - using Arrays */

//string[] arr1 = Console.ReadLine().Split(" ");
//string[] arr2 = Console.ReadLine().Split(" ");

//int smallerLength = Math.Min(arr1.Length, arr2.Length);
//int largerLength = Math.Max(arr1.Length, arr2.Length);

//string[] largerArr = (arr1.Length >= arr2.Length) ? arr1 : arr2;

//string[] mergedArr = new string[arr1.Length + arr2.Length];
//int indexMerged = 0;

//for (int i = 0; i < smallerLength; i++)
//{
//    mergedArr[indexMerged++] = arr1[i];
//    mergedArr[indexMerged++] = arr2[i];
//}

//for (int i = smallerLength; i < largerLength; i++)
//{
//    mergedArr[indexMerged++] = largerArr[i];
//}

//Console.WriteLine(string.Join(" ", mergedArr));


/* VAR 2 - using Lists */

List<string> list1 = Console.ReadLine().Split(" ").ToList();
List<string> list2 = Console.ReadLine().Split(" ").ToList();

List<string> mergedList = new List<string>();

while (list1.Count() > 0 && list2.Count > 0)
{
    mergedList.Add(list1[0]);
    mergedList.Add(list2[0]);
    list1.RemoveAt(0);
    list2.RemoveAt(0);
}

if (list1.Count > 0)
{
    mergedList.AddRange(list1);
}
else if (list2.Count > 0)
{
    mergedList.AddRange(list2);
}

Console.WriteLine(string.Join(" ", mergedList));