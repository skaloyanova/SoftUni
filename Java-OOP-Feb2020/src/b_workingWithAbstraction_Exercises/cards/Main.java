package b_workingWithAbstraction_Exercises.cards;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String input = sc.nextLine();

        switch (input) {
            case "Card Suits":
                System.out.println(String.format("%s:%n%s", input, suitsOutput()));
                break;
            case "Card Ranks":
                System.out.println(String.format("%s:%n%s", input, ranksOutput()));
                break;
            default:
                String cardRank = input;
                String cardSuit = sc.nextLine();
                Card card = new Card(CardRank.valueOf(cardRank), CardSuit.valueOf(cardSuit));
                System.out.println(card);
        }
    }

    private static String ranksOutput() {
        StringBuilder sb = new StringBuilder();
        for (CardRank card : CardRank.values()) {
            sb.append(String.format("Ordinal value: %d; Name value: %s%n", card.ordinal(), card.name()));
        }
        return sb.toString();
    }

    private static String suitsOutput() {
        StringBuilder sb = new StringBuilder();
        for (CardSuit card : CardSuit.values()) {
            sb.append(String.format("Ordinal value: %d; Name value: %s%n", card.ordinal(), card.name()));
        }
        return sb.toString();
    }
}
