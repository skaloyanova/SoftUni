//OutFall 4 -> $39.99
//CS: OG -> $15.99
//Zplinter Zell -> $19.99
//Honored 2 -> $59.99
//RoverWatch -> $29.99
//RoverWatch Origins Edition -> $39.99

double money = double.Parse(Console.ReadLine());    //[0.00…5000.00]
string game = Console.ReadLine();

double moneySpent = 0;

while (game != "Game Time")
{
    double gamePrice = getGamePrice(game);

    if (gamePrice == 0) //game is not in the list
    {
        Console.WriteLine("Not Found");
        game = Console.ReadLine();
        continue;
    }

    moneySpent += gamePrice;

    if (moneySpent <= money)
    {
        Console.WriteLine("Bought " + game);
    }

    if (moneySpent == money)
    {
        Console.WriteLine("Out of money!");
        return;
    }
    if (moneySpent > money)
    {
        moneySpent -= gamePrice;
        Console.WriteLine("Too Expensive");
    }


    game = Console.ReadLine();
}

Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${(money - moneySpent):f2}");

double getGamePrice(string gameName)
{
    switch (gameName)
    {
        case "OutFall 4": return 39.99;
        case "CS: OG": return 15.99;
        case "Zplinter Zell": return 19.99;
        case "Honored 2": return 59.99;
        case "RoverWatch": return 29.99;
        case "RoverWatch Origins Edition": return 39.99;
        default: return 0;
    }
}