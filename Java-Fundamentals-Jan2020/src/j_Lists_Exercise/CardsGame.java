package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Scanner;

public class CardsGame {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        ArrayList<Integer> deck1 = readIntList(sc);
        ArrayList<Integer> deck2 = readIntList(sc);

        while (deck1.size() > 0 && deck2.size() > 0) {
            int deck1Card = deck1.get(0);
            int deck2Card = deck2.get(0);

            if (deck1Card > deck2Card) {
                deck1.add(deck1Card);
                deck1.add(deck2Card);
                removeFirstCard(deck1, deck2);
            } else if (deck2Card > deck1Card) {
                deck2.add(deck2Card);
                deck2.add(deck1Card);
                removeFirstCard(deck1, deck2);
            } else {                        //deck1Card == deck2Card
                removeFirstCard(deck1, deck2);
            }
        }

        int sum = 0;
        if (deck1.size() > 0) {
            for (Integer num : deck1) {
                sum += num;
            }
            System.out.println("First player wins! Sum: " + sum);
        } else if (deck2.size() > 0) {
            for (Integer num : deck2) {
                sum += num;
            }
            System.out.println("Second player wins! Sum: " + sum);
        }

    }

    private static void removeFirstCard(ArrayList<Integer> deck1, ArrayList<Integer> deck2) {
        deck1.remove(0);
        deck2.remove(0);
    }

    private static ArrayList<Integer> readIntList(Scanner sc) {
        String[] input = sc.nextLine().split("\\s+");
        ArrayList<Integer> listToRead = new ArrayList<>();
        for (String element : input) {
            listToRead.add(Integer.parseInt(element));
        }
        return listToRead;
    }
}
