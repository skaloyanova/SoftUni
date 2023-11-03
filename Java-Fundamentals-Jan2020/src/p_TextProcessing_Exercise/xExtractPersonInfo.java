package p_TextProcessing_Exercise;

import java.util.Scanner;

public class xExtractPersonInfo {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < n; i++) {
            String text = sc.nextLine();
            int indexNameStart = text.indexOf("@");
            int indexNameEnd = text.indexOf("|");
            int indexAgeStart = text.indexOf("#");
            int indexAgeEnd = text.indexOf("*");

            String name = text.substring(indexNameStart + 1, indexNameEnd);
            String age = text.substring(indexAgeStart + 1, indexAgeEnd);

            System.out.println(String.format("%s is %s years old.", name, age));
        }
    }
}
