package h_Methods_Exercise;

import java.util.Scanner;

public class PasswordValidator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String pwd = sc.nextLine();

        validatePassword(pwd);
    }

    private static void validatePassword(String password) {
        if (pwdLengthCheck(password) && pwdSymbolCheck(password) && pwdDigitCountCheck(password)) {
            System.out.println("Password is valid");
        }

        if (!pwdLengthCheck(password)) {
            System.out.println("Password must be between 6 and 10 characters");
        }
        if (!pwdSymbolCheck(password)) {
            System.out.println("Password must consist only of letters and digits");
        }
        if (!pwdDigitCountCheck(password)) {
            System.out.println("Password must have at least 2 digits");
        }
    }

    private static boolean pwdLengthCheck(String password) {
        //Password must be between 6 and 10 characters

        return (password.length() >= 6) && (password.length() <= 10);
    }

    private static boolean pwdSymbolCheck(String password) {
        //Password must consist only of letters and digits

        return digitCount(password) + letterCount(password) == password.length();
    }

    private static boolean pwdDigitCountCheck(String password) {
        //Password must have at least 2 digits

        return digitCount(password) >= 2;
    }

    private static int digitCount(String password) {
        int digitCnt = 0;

        for (int i = 0; i < password.length(); i++) {
            if (password.charAt(i) >= '0' && password.charAt(i) <= '9') {
                digitCnt++;
            }
        }
        return digitCnt;
    }

    private static int letterCount(String password) {
        password = password.toLowerCase();
        int letterCnt = 0;

        for (int i = 0; i < password.length(); i++) {
            if (password.charAt(i) >= 'a' && password.charAt(i) <= 'z') {
                letterCnt++;
            }
        }
        return letterCnt;
    }

}
