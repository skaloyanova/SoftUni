namespace _03.SumOfPrimeAndNonPrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }

                int num = int.Parse(input);

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                //check if number is prime number
                bool isPrime = true;
                if(num == 0 || num == 1)   // 0 and 1 are not prime numbers
                {
                    isPrime = false;
                }

                for (int i = 2; i < num; i++)
                {
                    if (num == 2)
                    {
                        continue;
                    }
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sumPrimeNumbers += num;
                }
                else
                {
                    sumNonPrimeNumbers += num;
                }

            }

            Console.WriteLine("Sum of all prime numbers is: " + sumPrimeNumbers);
            Console.WriteLine("Sum of all non prime numbers is: " + sumNonPrimeNumbers);
        }
    }
}