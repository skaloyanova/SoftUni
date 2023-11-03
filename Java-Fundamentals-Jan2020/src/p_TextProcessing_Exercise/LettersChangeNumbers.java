package p_TextProcessing_Exercise;

import java.util.Scanner;

public class LettersChangeNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s+");

        double sum = 0;

        for (String word : input) {
            char firstLetter = word.charAt(0);
            char lastLetter = word.charAt(word.length() - 1);
            double number = Double.parseDouble(word.substring(1, word.length() - 1));

            double resultPerWord = 0;

            if (Character.isUpperCase(firstLetter)) {
                int position = firstLetter - 64;
                resultPerWord += number * 1.0 / position;
            } else {
                int position = firstLetter - 96;
                resultPerWord += number * position;
            }

            if (Character.isUpperCase(lastLetter)) {
                int position = lastLetter - 64;
                resultPerWord -= position;
            } else {
                int position = lastLetter - 96;
                resultPerWord += position;
            }

            sum += resultPerWord;
        }
        System.out.printf("%.2f", sum);
    }
}
