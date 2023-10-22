/*
 * Read a sequence of integer numbers from the console
 * Condense them by summing adjacent couples of elements until a single integer is obtained
 *	    Example: If we have 3 elements {2, 10, 3}. We sum the first two and the second two elements and obtain 
 *	           {2+10, 10+3} = {12, 13}. Then we sum again all adjacent elements and obtain {12+13} = {25}.
 */


/* VAR 1 - using Array */

//int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

//for (int i = 0; i < numbers.Length - 1; i++)
//{
//    for (int index = 0; index < numbers.Length - 1; index++)
//    {
//        numbers[index] = numbers[index] + numbers[index + 1];
//    }
//}

//Console.WriteLine(numbers[0]);


/* VAR 2 - using List */

List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();   //2 10 3
int index = 0;

while (numbers.Count > 1)
{
    int sum = numbers[index] + numbers[index + 1];
    numbers.RemoveAt(index);
    numbers.Insert(index, sum);

    index++;

    if (index == numbers.Count() - 1)
    {
        numbers.RemoveAt(index);
        index = 0;
    }
}

Console.WriteLine(numbers[0]);