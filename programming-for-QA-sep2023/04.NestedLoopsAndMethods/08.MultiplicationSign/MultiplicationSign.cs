namespace _08.MultiplicationSign
{
    internal class MultiplicationSign
    {
        static void Main(string[] args)
        {
            // INPUT - Read three integer numbers (num1, num2 and num3) from the console
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            // LOGIC + OUTPUT - Find and print if num1 * num2 * num3 (the product) is negative, positive or zero. Do this WITHOUT multiplying the three numbers.
            int negativeCount = 0;

            string signNum1 = GetNumberSign(num1);
            string signNum2 = GetNumberSign(num2);
            string signNum3 = GetNumberSign(num3);

            if (signNum1 == "zero" || signNum2 == "zero" || signNum3 == "zero")
            {
                Console.WriteLine("zero");
                return;
            }

            if (signNum1 == "negative")
            {
                negativeCount++;
            }

            if (signNum2 == "negative")
            {
                negativeCount++;
            }

            if (signNum3 == "negative")
            {
                negativeCount++;
            }

            if (negativeCount % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }

        }

        // METHOD
        static string GetNumberSign(int num)
        {
            if (num < 0)
            {
                return "negative";
            }
            else if (num == 0)
            {
                return "zero";
            }
            else
            {
                return "positive";
            }
        }
    }
}