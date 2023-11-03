namespace _07.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountToReturn = double.Parse(Console.ReadLine());

            // Calculates how amount can be returned with the minimum possible number of coins
            // Coins accepted by the vending machine: 2 leva, 1 lev, 50 stotinki, 20 stotinki, 10 stotinki, 5 stotinki, 2 stotinki, 1 stotinka

            int amountInCoins = (int)(amountToReturn * 100);    //convert the sum from leva and stotinki to stotinki only

            int coins = 0;

            coins += amountInCoins / 200;           //number of 2 leva coins
            amountInCoins = amountInCoins % 200;    //calculate the rest of the money

            coins += amountInCoins / 100;           //number of 1 lev coins
            amountInCoins = amountInCoins % 100;    //calculate the rest of the money

            coins += amountInCoins / 50;           //number of 50 stotinki coins
            amountInCoins = amountInCoins % 50;    //calculate the rest of the money

            coins += amountInCoins / 20;           //number of 20 stotinki coins
            amountInCoins = amountInCoins % 20;    //calculate the rest of the money

            coins += amountInCoins / 10;           //number of 10 stotinki coins
            amountInCoins = amountInCoins % 10;    //calculate the rest of the money

            coins += amountInCoins / 5;           //number of 5 stotinki coins
            amountInCoins = amountInCoins % 5;    //calculate the rest of the money

            coins += amountInCoins / 2;           //number of 2 stotinki coins
            amountInCoins = amountInCoins % 2;    //calculate the rest of the money

            coins += amountInCoins / 1;           //number of 1 stotinki coins

            Console.WriteLine(coins);
        }
    }
}