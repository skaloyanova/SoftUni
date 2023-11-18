/*
 * You will be given a sequence of strings, each on a new line. Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper and so on) and every even - quantity.
 * Your task is to collect the resources and print them each on a new line.
 * Print the resources and their quantities in the following format: "{resource} –> {quantity}"
 * The quantities will be in the range [1 … 2 000 000 000].
 */

string resource = Console.ReadLine();

Dictionary<string, long> resources = new();

// Fill in the map with values
while (resource != "stop")
{
    int quantity = int.Parse(Console.ReadLine());

    if (!resources.ContainsKey(resource))
    {
        resources.Add(resource, quantity);
    }
    else
    {
        resources[resource] += quantity;
    }

    resource = Console.ReadLine();
}

// Output
resources.Select(e => $"{e.Key} -> {e.Value}").ToList().ForEach(e => Console.WriteLine(e));