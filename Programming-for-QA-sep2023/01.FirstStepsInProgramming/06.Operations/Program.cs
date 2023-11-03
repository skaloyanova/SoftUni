namespace _06.Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());   //range [0...40 000]
            int num2 = int.Parse(Console.ReadLine());   //range [0...40 000]
            string operation = Console.ReadLine();      //"+", "-", "*", "/", "%"

            double result = 0;
            string output = String.Format($"{num1} {operation} {num2}");

            if (num2 == 0 && (operation == "/" || operation == "%"))
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
                return;
            }

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    output += String.Format($" = {result} - {evenOrOdd(result)}");
                    break;
                case "-":
                    result = num1 - num2;
                    output += String.Format($" = {result} - {evenOrOdd(result)}");
                    break;
                case "*":
                    result = num1 * num2;
                    output += String.Format($" = {result} - {evenOrOdd(result)}");
                    break;
                case "/":
                    result = (num1 * 1.0) / num2;
                    output += String.Format($" = {result:f2}");
                    break;
                case "%":
                    result = num1 % num2;
                    output += String.Format($" = {result}");
                    break;
            }

            Console.WriteLine(output);


            string evenOrOdd(double num)
            {
                if (num % 2 == 0)
                {
                    return "even";
                }
                else
                {
                    return "odd";
                }
            }
        }

    }
}