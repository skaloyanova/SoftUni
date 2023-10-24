/*
 * Reads a sequence of integer numbers from the console
 * Sum all adjacent equal numbers in a list of decimal numbers, starting from left to right
 *      After two numbers are summed, the obtained result could be equal to some of its neighbors and should be summed as well
 *      Always sum the leftmost two equal neighbors (if several couples of equal neighbors are available)
 * Example: 3 3 6 1 -> 6 6 1 -> 12 1
 * Example: 8 2 2 4 8 16 -> 8 4 4 8 16 -> 8 8 8 16 -> 16 8 16
 */

List<double> numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToList();
int index = 0;

while (index < numbers.Count - 1)	//index should be less that the last index in the list
{
	double n1 = numbers[index];
	double n2 = numbers[index + 1];

	if (n1 == n2)
	{
		numbers.RemoveAt(index);		//remove n1
		numbers.RemoveAt(index);		//remove n2
		numbers.Insert(index, n1 + n2); //add the sum on the place where n1 and n2 were located in the list

		if (index > 0)		//if we are not in the beggining of the list, go to the previous element to compare it with this sum
		{
			index--;
		}
	}
	else
	{
		index++;
	}
}

Console.WriteLine(string.Join(" ", numbers));