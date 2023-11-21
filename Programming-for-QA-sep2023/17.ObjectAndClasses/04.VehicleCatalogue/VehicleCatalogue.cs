namespace _04.VehicleCatalogue
{
    internal class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            // INPUT: read the input, until you receive the "end" command.
            // It will be in following format: "{type}/{brand}/{model}/{horse power / weight}"

            var catalogue = new Catalog();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] split = input.Split("/");

                string type = split[0];
                string brand = split[1];
                string model = split[2];
                int hpOrWeight = int.Parse(split[3]);

                if (type == "Car")
                {
                    catalogue.Cars.Add(new Car(brand, model, hpOrWeight));
                }
                else if (type == "Truck")
                {
                    catalogue.Trucks.Add(new Truck(brand, model, hpOrWeight));
                }

                input = Console.ReadLine();
            }

            /* OUTPUT: print all of the vehicles ordered alphabeticaly by brand
             * Cars:
             * {Brand}: {Model} - {Horse Power}hp
             * Trucks:
             * {Brand}: {Model} - {Weight}kg
             */

            //catalogue.Cars.Sort((a, b) => a.Brand.CompareTo(b.Brand));
            //catalogue.Trucks.Sort((a, b) => a.Brand.CompareTo(b.Brand));

            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                catalogue
                    .Cars
                    .OrderBy(c => c.Brand)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));
            }

            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                catalogue
                    .Trucks
                    .OrderBy(t => t.Brand)
                    .ToList()
                    .ForEach(t => Console.WriteLine(t));
            }
        }
    }

    /* ALL Classes are in one place, because solutions are tested this way in Judge system */

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }

    public class Catalog
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }

        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
    }
}