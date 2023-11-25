using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _09.VehicleCatalogue2
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public Vehicle(string type, string model, string color, double horsePower)
        {
            this.Type = char.ToUpper(type[0]) + type.Substring(1).ToLower();    //changing "car/truck" to "Car/Truck"
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string GetVehicleDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePower}");

            return sb.ToString().Trim();
        }
    }
}
