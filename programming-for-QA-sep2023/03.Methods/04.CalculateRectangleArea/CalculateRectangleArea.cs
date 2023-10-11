// INPUT
int width = int.Parse(Console.ReadLine());
int length = int.Parse(Console.ReadLine());

//OUTPUT
Console.WriteLine(getRectangleArea(width, length));

//METHOD for calculating area of rectangle
int getRectangleArea (int a, int b)
{
    return a * b;
}