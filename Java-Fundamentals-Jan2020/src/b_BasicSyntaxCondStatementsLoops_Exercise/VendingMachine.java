package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class VendingMachine {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String command = "";

        double money = 0;

        while (true) {
            command = sc.nextLine();

            if (command.equals("Start")) {
                break;
            }

            double coin = Double.parseDouble(command);
            if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2) {
                money += coin;
            } else {
                System.out.println(String.format("Cannot accept %.2f", coin));
            }
        }

        while (true) {
            command = sc.nextLine();

            double price = 0;

            switch (command) {
                case "Nuts": price = 2; break;
                case "Water": price = 0.7; break;
                case "Crisps": price = 1.5; break;
                case "Soda": price = 0.8; break;
                case "Coke": price = 1; break;
                case "End": break;
                default:
                    System.out.println("Invalid product");
                    break;
            }

            if (command.equals("End")) {
                System.out.println(String.format("Change: %.2f", money));
                break;
            }

            if (money < price) {
                System.out.println("Sorry, not enough money");
            } else if (money >= price && price != 0) {
                System.out.println(String.format("Purchased %s", command));
                money -= price;
            }
        }
    }
}
