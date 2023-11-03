package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class LowerOrUpper {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char letter = sc.nextLine().charAt(0);

        if (letter >= 65 && letter <= 90) {
            System.out.println("upper-case");
        } else if (letter >= 97 && letter <= 122) {
            System.out.println("lower-case");
        }
    }
}
