/*
 * Reads a sequence of integer numbers from the first line of the console
 * Read a special bomb number (integer) and its power (integer) from the second line of the console
 * Detonate every occurrence of the special bomb number and according to its power - his neighbors from left and right
 * Detonations are performed from left to right, and all detonated numbers disappear
 * Print the sum of the remaining elements in the sequence
 * 
 * Example: 
 *  Line 1: 1 4 4 2 8 9 1
 *  Line 2: 9 3
 *  The special number is 9 with power 3. After detonation, we left with the sequence [1, 4] with sum 5.
 *  Since the 9 has only 1 neighbor from the right, we remove just it (one number instead of 3).
 */

List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

string[] bomb = Console.ReadLine().Split(" ");
int bombNumber = int.Parse(bomb[0]);
int bombPower = int.Parse(bomb[1]);

int bombIndex = numbers.FindIndex(0, numbers.Count, e => e == bombNumber);

while (bombIndex >= 0)
{
    int left = bombIndex - bombPower;
    int right = bombIndex + bombPower;

    int startIndex = (left < 0) ? 0 : left;
    int endIndex = (right > numbers.Count - 1) ? numbers.Count - 1 : right;

    int count = endIndex - startIndex + 1;

    numbers.RemoveRange(startIndex, count);

    bombIndex = numbers.FindIndex(0, numbers.Count, e => e == bombNumber);  //returns -1 if there is no such element
}
 
Console.WriteLine(numbers.Sum());
