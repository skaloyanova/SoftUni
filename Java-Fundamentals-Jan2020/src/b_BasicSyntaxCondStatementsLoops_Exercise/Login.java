package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class Login {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String username = sc.nextLine();

        String validPass = "";
        for (int i = username.length() - 1; i >= 0; i--) {
            validPass = validPass + username.charAt(i);
        }

        for (int i = 1; i <= 4; i++) {
            String password = sc.nextLine();
            if (password.equals(validPass)) {
                System.out.printf("User %s logged in.", username);
                break;
            } else {
                if (i < 4) {
                    System.out.println("Incorrect password. Try again.");
                } else {
                    System.out.printf("User %s blocked!", username);
                }
            }
        }
    }
}
