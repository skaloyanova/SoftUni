// INPUT
int width = int.Parse(Console.ReadLine());
int length = int.Parse(Console.ReadLine());

//OUTPUT
Console.WriteLine(GetRectangleArea(width, length));

//METHOD for calculating area of rectangle
int GetRectangleArea (int a, int b)
{
    return a * b;
}