/*
 * Create a program that counts all characters in a string, except for space (' '). 
 * Print all the occurrences, each on new line in the following format: "{char} -> {occurrences}"
 * Example -> Input: text text text // Output: t -> 6 / e -> 3 / x -> 3
 */

/* VAR 1 */

//Dictionary<char, int> occurrences = Console.ReadLine()
//    .ToCharArray()
//    .Where(c => c !=  ' ')
//    .GroupBy(c => c)
//    .ToDictionary(c => c.Key, c => c.Count());

//foreach (KeyValuePair<char, int> pair in occurrences)
//{
//    Console.WriteLine($"{pair.Key} -> {pair.Value}");
//}


/* VAR 2 */

Console.ReadLine()
    .ToCharArray()
    .Where(c => c != ' ')
    .GroupBy(c => c)
    .ToDictionary(c => c.Key, c => c.Count())
    .Select(c => $"{c.Key} -> {c.Value}")
    .ToList()
    .ForEach(e => Console.WriteLine(e));