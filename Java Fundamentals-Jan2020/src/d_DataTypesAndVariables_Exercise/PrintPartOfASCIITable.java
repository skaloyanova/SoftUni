package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class PrintPartOfASCIITable {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int startCharIndex = Integer.parseInt(sc.nextLine());
        int lastCharIndex = Integer.parseInt(sc.nextLine());

        for (char i = (char) startCharIndex; i <= (char) lastCharIndex; i++) {
            System.out.print(i + " ");
        }
    }
}
