package x_ArchivedExercises;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class e03_SplitByWordCasing {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] text = sc.nextLine().split("[,;:.!()\"'\\\\\\/\\[\\]\\s]+");

        List<String> upper = new ArrayList<>();
        List<String> lower = new ArrayList<>();
        List<String> mixed = new ArrayList<>();

        for (String word : text) {
            String result = letterCase(word);
            switch (result) {
                case "up": upper.add(word); break;
                case "low": lower.add(word); break;
                case "mix": mixed.add(word); break;
            }
        }
        System.out.println("Lower-case: " + lower.toString().replaceAll("[\\[\\]]", ""));
        System.out.println("Mixed-case: " + mixed.toString().replaceAll("[\\[\\]]", ""));
        System.out.println("Upper-case: " + upper.toString().replaceAll("[\\[\\]]", ""));
    }

    private static String letterCase(String word) {
        String result = "";
        int up = 0;
        int low = 0;
        for (int i = 0; i < word.length(); i++) {
            if (Character.isUpperCase(word.charAt(i))) {
                up++;
            } else if (Character.isLowerCase(word.charAt(i))) {
                low++;
            }
        }
        return up == word.length() ? "up" : low == word.length() ? "low" : "mix";
    }
}
