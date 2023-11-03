package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class Vacation {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int people = Integer.parseInt(sc.nextLine());
        String groupType = sc.nextLine();
        String day = sc.nextLine();

        double price = 0;

        switch (groupType) {
            case "Students":
                switch (day) {
                    case "Friday": price = 8.45; break;
                    case "Saturday": price = 9.80; break;
                    case "Sunday": price = 10.46; break;
                }
                if (people >= 30) {
                    price -= 0.15 * price;
                }
                break;
            case "Business":
                switch (day) {
                    case "Friday": price = 10.90; break;
                    case "Saturday": price = 15.60; break;
                    case "Sunday": price = 16; break;
                }
                if (people >= 100) {
                    people -= 10;
                }
                break;
            case "Regular":
                switch (day) {
                    case "Friday": price = 15; break;
                    case "Saturday": price = 20; break;
                    case "Sunday": price = 22.50; break;
                }
                if (people >= 10 && people <= 20) {
                    price -= 0.05 * price;
                }
                break;
        }

        price = price * people;

        System.out.printf("Total price: %.2f", price);

    }
}
