double eps = 0.000001;

double num1 = double.Parse(Console.ReadLine());
double num2 = double.Parse(Console.ReadLine());

double diff = Math.Abs(num1 - num2);

bool isEqual = diff < eps;

Console.WriteLine(isEqual);