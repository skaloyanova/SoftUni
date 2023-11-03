package b_workingWithAbstraction_Exercises.cards;

public class Card {
    private int power;
    private CardRank rank;
    private CardSuit suit;

    public Card(CardRank rank, CardSuit suit) {
        this.rank = rank;
        this.suit = suit;
        setPower();
    }

    public void setPower() {
        this.power = this.rank.getPower() + this.suit.getPower();
    }

    @Override
    public String toString() {
        return String.format("Card name: %s of %s; Card power: %d", this.rank, this.suit, this.power);
    }
}
