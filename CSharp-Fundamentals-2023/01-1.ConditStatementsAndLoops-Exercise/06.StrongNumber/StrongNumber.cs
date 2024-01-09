// Write a program that receives a single integer and calculates if it's strong or not.
// A number is strong, if the sum of the factorials of each digit is equal to the number itself.
// Example: 145 is a strong number, because 1! + 4! + 5! = 145. 

int num = int.Parse(Console.ReadLine());

int tempNum = num;

int sum = 0;

while (tempNum > 0)
{
    int digit = tempNum % 10;
    tempNum = tempNum / 10;

    sum += factorial(digit);
}

Console.WriteLine((num == sum)?"yes":"no");

//Defining functuon for calculating factorial
int factorial(int x) {

    int result = 1;
    for (int i = 1; i <= x; i++)
    {
        result *= i;
    }

    return result;
}
