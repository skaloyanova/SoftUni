using _09.VehicleCatalogue2;

Catalogue catalogue = new();

// CREATE VEHICLES

string input = Console.ReadLine();

while (input.ToLower() != "end")
{
    string[] split = input.Split();     //input format: {typeOfVehicle} {model} {color} {horsepower}
    string type = split[0].ToLower();

    if (type == "car")
    {
        catalogue.Cars.Add(new Vehicle(type, split[1], split[2], double.Parse(split[3])));
    }
    else if (type == "truck")
    {
        catalogue.Trucks.Add(new Vehicle(type, split[1], split[2], double.Parse(split[3])));
    }
    
    input = Console.ReadLine();
}

// SEARCH VEHICLES CATALOGUE

string modelRequest = Console.ReadLine();

while (modelRequest != "Close the Catalogue")
{
    Vehicle requestedVehicle = catalogue.GetVehicle(modelRequest);      //if vehicle is not found, null will be assigned

    if (requestedVehicle != null)
    {
        Console.WriteLine(requestedVehicle.GetVehicleDetails());
    }

    modelRequest = Console.ReadLine();
}

// Print out the average horsepower of the cars and the average horsepower (formtted to second digit after the decimal point) of the trucks in the format:
// "{typeOfVehicles} have average horsepower of: {averageHorsepower}."

if (catalogue.GetCarsAverageHorsePower() >= 0)
{
    Console.WriteLine($"Cars have average horsepower of: {catalogue.GetCarsAverageHorsePower():f2}.");
}

if (catalogue.GetTrucksAverageHorsePower() >= 0)
{
    Console.WriteLine($"Trucks have average horsepower of: {catalogue.GetTrucksAverageHorsePower():f2}.");
}



/*
using _09.VehicleCatalogue2;

List<Vehicle> vehicles = new();

// CREATE VEHICLES

string input = Console.ReadLine();

while (input != "End")
{
    string[] split = input.Split();     //input format: {typeOfVehicle} {model} {color} {horsepower}
    string type = char.ToUpper(split[0][0]) + split[0].Substring(1).ToLower();    //changing "car/truck" to "Car/Truck"

    vehicles.Add(new Vehicle(type, split[1], split[2], double.Parse(split[3])));

    input = Console.ReadLine();
}

// SEARCH VEHICLES CATALOGUE

string vehicleModelRequest = Console.ReadLine();

while (vehicleModelRequest != "Close the Catalogue")
{
    Vehicle requestedVehicle = vehicles.Find(v => v.Model == vehicleModelRequest);      //if vehicle is not found, null will be assigned

    if (requestedVehicle != null)
    {
        Console.WriteLine(requestedVehicle.GetVehicleDetails());
    }
    
    vehicleModelRequest = Console.ReadLine();
}

// Print out the average horsepower of the cars and the average horsepower (formtted to second digit after the decimal point) of the trucks in the format:
// "{typeOfVehicles} have average horsepower of: {averageHorsepower}."

if (vehicles.Any(v => v.Type == "Car"))
{
    double carsAverageHosrsePower = vehicles
    .Where(v => v.Type == "Car")
    .Average(v => v.HorsePower);

    Console.WriteLine($"Cars have average horsepower of: {carsAverageHosrsePower:f2}.");
}

if (vehicles.Any(v => v.Type == "Truck"))
{
    double trucksAverageHosrsePower = vehicles
    .Where(v => v.Type == "Truck")
    .Average(v => v.HorsePower);

    Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHosrsePower:f2}.");
}
*/