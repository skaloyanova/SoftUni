package o_TextProcessing;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class RepeatStrings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<String> words = Arrays.stream(sc.nextLine().split(" ")).collect(Collectors.toList());

        String result = "";
        for (String word : words) {
            result += repeat(word);
        }
        System.out.println(result);
    }

    private static String repeat(String word) {
        String result = "";
        for (int i = 0; i < word.length(); i++) {
            result += word;
        }
        return result;
    }
}
