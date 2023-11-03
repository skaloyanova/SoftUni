package z_Exam_20180103_archived;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DharmaSupplies {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String input = sc.nextLine();
        String regexCrate = "\\[.*?]";
        Pattern pattern = Pattern.compile(regexCrate);

        List<String> crates = new ArrayList<>();
        int linesCount = 0;

        while (!"Collect".equals(input)) {
            linesCount++;
            Matcher matcher = pattern.matcher(input);
            while (matcher.find()) {
                crates.add(matcher.group(0));
            }
            input = sc.nextLine();
        }

        int n = crates.size() / linesCount;

        String regexSupply = "\\[(?<tag>(#[0-9]{" + n + "}|#[a-z]{" + n + "}))(?<body>[a-zA-Z0-9\\s]+)\\1]";

        Pattern patternSupply = Pattern.compile(regexSupply);

        int supplyCratesCount = 0;
        int food = 0;
        int drink = 0;

        for (String crate : crates) {
            Matcher matcherSupply = patternSupply.matcher(crate);

            if (matcherSupply.matches()) {
                supplyCratesCount++;
                String tag = matcherSupply.group("tag");
                String body = matcherSupply.group("body");

                if (Character.isDigit(tag.charAt(1))) {     //food tag
                    Set<Character> bodyChars = new HashSet<>();

                    for (int i = 0; i < body.length(); i++) {
                        bodyChars.add(body.charAt(i));
                    }

                    int sumBodyChars = 0;
                    for (char bodyChar : bodyChars) {
                        sumBodyChars += bodyChar;
                    }

                    food += sumBodyChars * n;
                } else {                                    // drink tag
                    int sumTagChars = 0;

                    for (int i = 1; i < tag.length(); i++) {
                        sumTagChars += tag.charAt(i);
                    }

                    int sumBodyChars = 0;
                    for (char bodyChar : body.toCharArray()) {
                        sumBodyChars += bodyChar;
                    }

                    drink += sumBodyChars * sumTagChars;
                }
            }
        }

        //output
        if (supplyCratesCount == 0) {
            System.out.println("No supplies found!");
        } else {
            System.out.println("Number of supply crates: " + supplyCratesCount);
            System.out.println("Amount of food collected: " + food);
            System.out.println("Amount of drinks collected: " + drink);
        }
    }
}
