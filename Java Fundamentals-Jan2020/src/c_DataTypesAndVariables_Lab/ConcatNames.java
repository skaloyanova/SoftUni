package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class ConcatNames {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String firstName = sc.nextLine();
        String lastName = sc.nextLine();
        String operator = sc.nextLine();

        System.out.println(firstName + operator + lastName);
    }
}
