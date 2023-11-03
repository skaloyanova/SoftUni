package a_BasicSyntaxCondStatementsLoops_Lab;

import java.util.Scanner;

public class TheatrePromotion {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String day = sc.nextLine();
        int age = Integer.parseInt(sc.nextLine());

        int price = 0;

        boolean error = false;

        if (age < 0) {
            error = true;
        } else if (age <= 18) {
            switch (day) {
                case "Weekday":
                    price = 12;
                    break;
                case "Weekend":
                    price = 15;
                    break;
                case "Holiday":
                    price = 5;
                    break;
            }

        } else if (age <= 64) {
            switch (day) {
                case "Weekday":
                    price = 18;
                    break;
                case "Weekend":
                    price = 20;
                    break;
                case "Holiday":
                    price = 12;
                    break;
            }
        } else if (age <= 122) {
            switch (day) {
                case "Weekday":
                    price = 12;
                    break;
                case "Weekend":
                    price = 15;
                    break;
                case "Holiday":
                    price = 10;
                    break;
            }
        } else {
            error = true;
        }


        if (error) {
            System.out.println("Error!");
        } else {
            System.out.printf("%d$", price);
        }
    }
}
