package h_Methods_Exercise;

import java.util.Scanner;

public class xDataTypes {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String type =sc.nextLine();
        String input = sc.nextLine();

        printResult(type, input);
    }

    private static void printResult(String type, String input) {
        double result;
        double num;

        switch (type.toLowerCase()) {
            case "int":
                num = Double.parseDouble(input);
                System.out.println(String.format("%.0f", num * 2));
                break;
            case "real":
                num = Double.parseDouble(input);
                System.out.println(String.format("%.2f", num * 1.5));
                break;
            case "string":
                System.out.println("$" + input + "$");
        }
    }
}
