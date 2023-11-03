namespace _02.EqualSumOfEvenAndOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());   //6-digit number
            int num2 = int.Parse(Console.ReadLine());   //6-digit number

            for (int i = num1; i <= num2; i++)
            {
                int currentNum = i;
                int sumEven = 0;    // sum of digits at postition 2,4,6 of the number
                int sumOdd = 0;     // sum of digits at positions 1,3,5 of the number
                int digitPosition = 6;

                while (currentNum > 0)
                {
                    int lastDigit = currentNum % 10;    //take the last digit of the number
                    currentNum = currentNum / 10;       //take the previous digits as new number

                    if (digitPosition % 2 == 0)
                    {
                        sumEven += lastDigit;
                    }
                    else
                    {
                        sumOdd += lastDigit;
                    }

                    digitPosition--;
                }

                if (sumEven == sumOdd)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}