/*
 * Read an array of strings, given on a single line, space-separated
 * Take only words, whose length is an even number
 * Print each word on a new line
 */

Console.ReadLine().Split().Where(e => e.Length % 2 == 0).ToList().ForEach(e => Console.WriteLine(e));
