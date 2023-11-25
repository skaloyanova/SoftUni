// print sum of digits of the bigger number -> left or right part of the input string

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    long[] nums = Console.ReadLine().Split().Select(long.Parse).ToArray();

    long bigger = nums[0] >= nums[1] ? nums[0] : nums[1];

    int sum = 0;
    foreach (char c in bigger.ToString())
    {
        if (c != '-')
        {
            sum += c - '0';
        }   
    }

    Console.WriteLine(sum);
}