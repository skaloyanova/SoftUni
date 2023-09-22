namespace _09.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int roomVolume = width * length * height;

            while (true) { 
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    Console.WriteLine($"{roomVolume} Cubic meters left.");
                    break;
                }

                int boxSize = int.Parse(input);

                roomVolume -= boxSize;

                if (roomVolume < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(roomVolume)} Cubic meters more.");
                    break;
                }
            }
        }
    }
}