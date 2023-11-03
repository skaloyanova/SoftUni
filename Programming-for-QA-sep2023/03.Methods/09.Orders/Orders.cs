//INPUT
// Read a string on the first line from the console, representing a product - "coffee",  "water", "coke" or "snacks"
// Read an integer on the second line from the console, representing the quantity of the product

string product = Console.ReadLine().ToLower();
int qty = int.Parse(Console.ReadLine());


//OUTPUT
// Print the result, rounded to the second decimal place

Console.WriteLine($"{CalculateTotalPrice(product, qty):f2}");


//METHOD
/*
 *	Create a method that calculates and prints the total price of an order
 *	The method should receive two parameters: product and quantity
 *	The prices for a single item of each product are:
 *	coffee – 1.50
 *	water – 1.00
 *	coke – 1.40
 *	snacks – 2.00
 */
double CalculateTotalPrice (string product, int qty)
{
    double price = 0;

    switch(product)
    {
        case "coffee": price = 1.50; break;
        case "water": price = 1.00; break;
        case "coke": price = 1.40; break;
        case "snacks": price = 2.00; break;
    }

    return price * qty;
}