namespace _06.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int totalSteps = 0;
            bool goingHome = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    goingHome = true;
                    input = Console.ReadLine();
                }

                int steps = int.Parse(input);

                totalSteps += steps;

                if (totalSteps >= goal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{totalSteps - goal} steps over the goal!");
                    break;
                }

                if (goingHome)
                {
                    Console.WriteLine($"{goal - totalSteps} more steps to reach goal.");
                    break;
                }
            }
        }
    }
}