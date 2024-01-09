// Accumulate money by inserting valid coins
double money = 0.0;string inputCoin = Console.ReadLine();while (inputCoin != "Start")
{
    double coin = double.Parse(inputCoin);

    //Check for valid coin
    if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
    {
        money += coin;
    }
    else
    {
        Console.WriteLine($"Cannot accept {coin}");
    }

    inputCoin = Console.ReadLine();
}


// Buy valid products
// • "Nuts" with a price of 2.0
// • "Water" with a price of 0.7
// • "Crisps" with a price of 1.5
// • "Soda" with a price of 0.8
// • "Coke" with a price of 1.0

string inputProduct = Console.ReadLine();

while (inputProduct != "End")
{
    double productPrice = 0;
    switch (inputProduct)
    {
        case "Nuts": productPrice = 2.0; break;
        case "Water": productPrice = 0.7; break;
        case "Crisps": productPrice = 1.5; break;
        case "Soda": productPrice = 0.8; break;
        case "Coke": productPrice = 1.0; break;
        default: 
            Console.WriteLine("Invalid product");
            inputProduct = Console.ReadLine();
            continue;
    }

    if (money - productPrice >= 0)
    {
        Console.WriteLine($"Purchased {inputProduct.ToLower()}");
        money -= productPrice;
    }
    else
    {
        Console.WriteLine("Sorry, not enough money");
    }

    inputProduct = Console.ReadLine();
}

Console.WriteLine($"Change: {money:f2}");