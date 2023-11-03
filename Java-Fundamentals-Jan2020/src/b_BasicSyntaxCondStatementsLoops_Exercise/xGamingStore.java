package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class xGamingStore {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        double money = Double.parseDouble(sc.nextLine());
        double remainingMoney = money;

        while (true) {
            String game = sc.nextLine();

            if (game.equals("Game Time")) {
                System.out.println(String.format("Total spent: $%.2f. Remaining: $%.2f",
                        (money - remainingMoney), remainingMoney));
                break;
            }

            double price = 0;

            switch (game) {
                case "OutFall 4": price = 39.99; break;
                case "CS: OG": price = 15.99; break;
                case "Zplinter Zell": price = 19.99; break;
                case "Honored 2": price = 59.99; break;
                case "RoverWatch": price = 29.99; break;
                case "RoverWatch Origins Edition": price = 39.99; break;
                default:
                    System.out.println("Not Found");
                    break;
            }

            if (remainingMoney >= price && price != 0) {
                System.out.println(String.format("Bought %s", game));
                remainingMoney -= price;
                if (remainingMoney == 0) {
                    System.out.println("Out of money!");
                     break;
                }
            } else if (remainingMoney < price){
                    System.out.println("Too Expensive");
            }
        }
    }
}
