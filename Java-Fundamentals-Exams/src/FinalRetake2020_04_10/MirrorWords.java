package FinalRetake2020_04_10;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class MirrorWords {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        String regex = "([@#])(?<word1>[A-Za-z]{3,})\\1\\1(?<word2>[A-Za-z]{3,})\\1";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(text);

        List<String> mirrors = new ArrayList<>();

        int count = 0;

        while (matcher.find()) {
            count++;
            String word1 = matcher.group("word1");
            String word2 = matcher.group("word2");
            StringBuilder word2Reversed = new StringBuilder(word2);
            word2Reversed = word2Reversed.reverse();

            if (word1.equals(word2Reversed.toString())) {
                String pair = word1 + " <=> " + word2;
                mirrors.add(pair);
            }
        }

        if (count == 0) {
            System.out.println("No word pairs found!");
        } else {
            System.out.println(count + " word pairs found!");
        }
        if (mirrors.size() == 0) {
            System.out.println("No mirror words!");
        } else {
            System.out.println("The mirror words are:");
            System.out.println(String.join(", ", mirrors));
        }
    }
}
