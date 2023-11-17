/*
 * Read a list of integers (given on a single line, space-separated)
 * Print them in ascending order, along with their number of occurrences in the format: {number} ->  {occurances}
 */

List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

SortedDictionary<int, int> counter = new SortedDictionary<int, int>();

/* VAR 3 */

//foreach (int num in numbers)
//{
//    int value = 0;
//    counter.TryGetValue(num, out value);

//    counter[num] = value + 1;
//}


/* VAR 2*/

foreach (int num in numbers)
{
    if (counter.ContainsKey(num))
    {
        counter[num]++;
    }
    else
    {
        counter[num] = 1;
    }   
}

/* VAR 1 */

//foreach (int num in numbers)
//{
//    int key = num;

//    if (map.ContainsKey(key))
//    {
//        map[key] = map.GetValueOrDefault(key) + 1;
//    }
//    else
//    {
//        map.Add(num, 1);
//    }
//}

// OUTPUT
foreach (KeyValuePair<int, int> kvp in counter)
{
    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
}