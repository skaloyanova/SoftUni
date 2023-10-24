/*
 * You will be given two hands of cards, which will be integer numbers.
 * Assume that you have two players. You must find the winning deck and, respectively, the winner.
 * 
 * You start from the beginning of both hands. Compare the cards from the first deck to those from the second.
 * The player, who has a bigger card, takes both cards and puts them on the back of his hand - the second player's card is last, 
 *      and the first person's card (the winning one) is before it (second to last), and the player with the smaller card must remove the card from his deck. 
 * If both players' cards have the same values - no one wins, and the two cards must be removed from the decks. 
 * 
 * The game is over when one of the decks is left without any cards. You have to print the winner on the console and the sum of the left cards: 
 *
 * Example: Line1 -> 20 30 40 50  // Line2 -> 10 20 30 40  // Output -> First player wins! Sum: 240
 */

List<int> deck1 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> deck2 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

while (deck1.Count > 0 && deck2.Count > 0)
{
    int card1 = deck1[0];
    int card2 = deck2[0];

    if (card1 > card2)
    {
        deck1.Add(card1);
        deck1.Add(card2);
    }
    else if (card2 > card1) 
    {
        deck2.Add(card2);
        deck2.Add(card1);
    }

    deck1.RemoveAt(0);
    deck2.RemoveAt(0);
}

if (deck1.Count > 0)
{
    Console.WriteLine($"First player wins! Sum: {deck1.Sum()}");
}
else if (deck2.Count > 0)
{
    Console.WriteLine($"Second player wins! Sum: {deck2.Sum()}");
}
