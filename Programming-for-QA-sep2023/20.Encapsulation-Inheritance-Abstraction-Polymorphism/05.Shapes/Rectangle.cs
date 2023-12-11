using Shapes;
using System;
using System.Text;

public class Rectangle : IDrawable
{
    private int _width;
    private int _height;

    public Rectangle(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException();
        }
        this._width = width;
        this._height = height;
    }
    public void Draw()
    {
        StringBuilder sb = new StringBuilder();
        string firstLastLine = new string('*', _width);
        string midLine = "*";
        if (_width > 1)
        {
            midLine += new string(' ', _width - 2) + '*';
        }
        Console.WriteLine(firstLastLine);

        for (int i = 1; i <= _height - 2; i++)
        {
            Console.WriteLine(midLine);
        }

        Console.WriteLine(firstLastLine);
    }
}