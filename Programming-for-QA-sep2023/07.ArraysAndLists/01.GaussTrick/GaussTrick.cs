/*
 * Read a sequence with integer numbers from the console
 * Sums all numbers in a list in the following order: 
 *  first + last, first + 1 + last - 1, first + 2 + last - 2, … first + n, last – n
 */

/* VAR 1 */

//int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
//List<int> sums = new List<int>();

//for (int i = 0; i < numbers.Length / 2; i++)
//{
//    int sum = numbers[i] + numbers[numbers.Length - 1 - i];
//    sums.Add(sum);
//}

//if (numbers.Length % 2 != 0)
//{
//    sums.Add(numbers[numbers.Length / 2]);
//}

//Console.WriteLine(string.Join(" ", sums));


/* VAR 2 */

List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

List<int> sums = new List<int>();

while (numbers.Count > 2)   //exit the loop when there are only 1 or 2 element left in the List
{
    int first = numbers[0];
    int last = numbers[numbers.Count - 1];

    sums.Add(first + last);

    numbers.RemoveAt(0);
    numbers.RemoveAt(numbers.Count - 1);
}

sums.Add(numbers.Sum());    //add the sum of the rest 1 or 2 elements

Console.WriteLine(string.Join(" ", sums));
