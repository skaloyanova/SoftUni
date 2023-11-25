using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.VehicleCatalogue2
{
    public class Catalogue
    {
        public List<Vehicle> Cars { get; set; }
        public List<Vehicle> Trucks { get; set; }

        public Catalogue()
        {
            this.Cars = new();
            this.Trucks = new();
        }

        public void Add(Vehicle vehicle)
        {
            if (vehicle.Type.ToLower() == "car")
            {
                this.Cars.Add(vehicle);
            }
            else if (vehicle.Type.ToLower() == "truck")
            {
                this.Trucks.Add(vehicle);
            }
        }

        public double GetCarsAverageHorsePower ()
        {
            return (Cars.Count == 0) ? 0 : Cars.Average(c => c.HorsePower);
        }

        public double GetTrucksAverageHorsePower()
        {
            return (Trucks.Count == 0) ? 0 : Trucks.Average(c => c.HorsePower);
        }

        public Vehicle GetVehicle(string model)
        {
            var vehicle = Cars.Find(c => c.Model == model);
            if (vehicle != null)
            {
                return vehicle;
            }

            return Trucks.Find(t => t.Model == model);
        }
    }
}
