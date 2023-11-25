using _09.VehicleCatalogue2;

Catalogue catalogue = new();

// CREATE VEHICLES

string input = Console.ReadLine();

while (input.ToLower() != "end")
{
    string[] split = input.Split();     //input format: {typeOfVehicle} {model} {color} {horsepower}
    string type = split[0].ToLower();
    string model = split[1];
    string color = split[2];
    double horsePower = double.Parse(split[3]);

    if (horsePower > 0)
    {
        var vehicle = new Vehicle(type, model, color, horsePower);
        catalogue.Add(vehicle);
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

// Print out the average horsepower of the cars and the average horsepower of the trucks in the format (formtted to second digit after the decimal point):
// "{typeOfVehicles} have average horsepower of: {averageHorsepower}."


Console.WriteLine($"Cars have average horsepower of: {catalogue.GetCarsAverageHorsePower():f2}.");
Console.WriteLine($"Trucks have average horsepower of: {catalogue.GetTrucksAverageHorsePower():f2}.");
