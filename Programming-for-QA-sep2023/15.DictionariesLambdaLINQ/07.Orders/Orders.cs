/*
 * Create a program that keeps the information about products and their prices.
 * Each product has a name, a price and a quantity.
 * If the product doesn't exist yet, add it with its starting quantity.
 * If you receive a product, which already exists, increase its quantity by the input quantity and if its price is different, replace the price as well.
 */

/* INPUT
 * Until you receive "buy", the products will be coming in the format: "{name} {price} {quantity}".
 * The product data is always delimited by a single space.
*/

string command = Console.ReadLine();

Dictionary<string, double[]> products = new();

while (command != "buy")
{
    string[] commandSplit = command.Split(" ");

    string product = commandSplit[0];
    double price = double.Parse(commandSplit[1]);
    int quantity = int.Parse(commandSplit[2]);

    if (!products.ContainsKey(product))
    {
        products.Add(product, new double[] { price, quantity });
    }
    else
    {
        products[product][0] = price;
        products[product][1] += quantity;
    }

    command = Console.ReadLine();
}


/* OUTPUT
 * Print information about each product in the following format: "{productName} -> {totalPrice}"
 * Format the average grade to the 2nd digit after the decimal separator.
 */

foreach (KeyValuePair<string, double[]> pair in products)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value[0] * pair.Value[1]:f2}");
}