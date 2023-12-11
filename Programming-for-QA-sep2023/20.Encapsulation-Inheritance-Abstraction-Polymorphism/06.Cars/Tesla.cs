using System;

namespace Cars;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }

    public Tesla(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public Tesla(string model, string color, int battery) : this(model, color)
    {
        this.Battery = battery;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Break!";
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries{Environment.NewLine}" +
            $"{this.Start()}{Environment.NewLine}" +
            $"{this.Stop()}";
    }
}
