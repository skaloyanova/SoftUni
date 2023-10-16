// VAR 1

//string input = Console.ReadLine();

//string[] nums = input.Split(" ");

//int sum = 0;

//foreach (string s in nums)
//{
//    sum += int.Parse(s);
//}

//Console.WriteLine(sum);


// VAR 2
int sum = Console.ReadLine().Split(" ").Select(int.Parse).Sum();
Console.WriteLine(sum);