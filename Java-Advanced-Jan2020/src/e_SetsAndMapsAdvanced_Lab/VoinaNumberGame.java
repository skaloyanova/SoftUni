package e_SetsAndMapsAdvanced_Lab;

import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class VoinaNumberGame {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Set<Integer> player1 = readInput(sc);
        Set<Integer> player2 = readInput(sc);

        int turns = 1;
        while (player1.size() > 0 && player2.size() > 0 && turns <= 50){
            int cardP1 = player1.iterator().next();
            player1.remove(cardP1);
            int cardP2 = player2.iterator().next();
            player2.remove(cardP2);

            if (cardP1 > cardP2) {
                player1.add(cardP1);
                player1.add(cardP2);
            } else if (cardP2 > cardP1) {
                player2.add(cardP1);
                player2.add(cardP2);
            }
            turns++;
        }
        if (player1.size() == 0 || player1.size() < player2.size()) {
            System.out.println("Second player win!");
        } else if (player2.size() == 0 || player2.size() < player1.size()) {
            System.out.println("First player win!");
        } else {
            System.out.println("Draw!");
        }
    }

    private static Set<Integer> readInput(Scanner sc) {
        Set<Integer> player = new LinkedHashSet<>();
        String[] input = sc.nextLine().split("\\s+");
        for (String s : input) {
            player.add(Integer.parseInt(s));
        }
        return player;
    }
}
