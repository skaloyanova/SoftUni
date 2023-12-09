using System;
using System.Text;

namespace BoxData;

public class Box
{
    private double _length;
    private double _width;
    private double _height;

    public double Length
    {
        get { return this._length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            this._length = value;
        }
    }
    public double Width
    {
        get { return this._width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            this._width = value;
        }
    }
    public double Height
    {
        get { return this._height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            this._height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double SurfaceArea()
    {
        return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    }

    public double Volume()
    {
        return Length * Width * Height;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Surface Area – {this.SurfaceArea():f2}");
        sb.AppendLine($"Volume – {this.Volume():f2}");

        return sb.ToString().Trim();
    }
}
