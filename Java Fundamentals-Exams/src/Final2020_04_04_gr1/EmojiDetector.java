package Final2020_04_04_gr1;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class EmojiDetector {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String text = sc.nextLine();

        final String REGEX = "(::|\\*\\*)(?<emoji>[A-Z][a-z]{2,})\\1";
        Pattern pattern = Pattern.compile(REGEX);
        Matcher matcher = pattern.matcher(text);

        Matcher thresholdMatch = Pattern.compile("\\d+").matcher(text);
        StringBuilder threshold = new StringBuilder();
        while (thresholdMatch.find()) {
            threshold.append(thresholdMatch.group());
        }
        int coolThreshold = 1;
        for (int i = 0; i < threshold.length(); i++) {
            coolThreshold *= Integer.parseInt(String.valueOf(threshold.charAt(i)));
        }

        int count = 0;
        StringBuilder emojies = new StringBuilder();
        while (matcher.find()) {
            count++;
            int coolness = 0;
            String emoji = matcher.group("emoji");
            for (int i = 0; i < emoji.length(); i++) {
                coolness += emoji.charAt(i);
            }
            if (coolness >= coolThreshold) {
                emojies.append(matcher.group(1));
                emojies.append(emoji);
                emojies.append(matcher.group(1)).append(System.lineSeparator());
            }
        }
        System.out.println("Cool threshold: " + coolThreshold);
        System.out.println(count + " emojis found in the text. The cool ones are:");
        System.out.println(emojies);

    }
}
