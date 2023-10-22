/*
 * Read a sequence with integer numbers from the console
 * Sums all numbers in a list in the following order: 
 *  first + last, first + 1 + last - 1, first + 2 + last - 2, … first + n, last – n
 */

/* VAR 1 */

//int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

//for (int i = 0; i < numbers.Length / 2; i++)
//{
//    Console.Write($"{numbers[i] + numbers[numbers.Length - 1 - i]} ");
//}

//if (numbers.Length % 2 != 0)
//{
//    Console.Write(numbers[numbers.Length / 2]);
//}

/* VAR 2 */

List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

while (numbers.Count > 2)   //exit the loop when there are only 1 or 2 element left in the List
{
    int first = numbers[0];
    int last = numbers[numbers.Count - 1];

    Console.Write($"{first + last} ");

    numbers.RemoveAt(0);
    numbers.RemoveAt(numbers.Count - 1);
}

Console.WriteLine(numbers.Sum());   //print the sum of the rest 1 or 2 elements
