package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class ReversedChars {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char symbol1 = sc.nextLine().charAt(0);
        char symbol2 = sc.nextLine().charAt(0);
        char symbol3 = sc.nextLine().charAt(0);

        String result = "" + symbol3 + " " + symbol2 + " " + symbol1;
        System.out.println(result);
    }
}
