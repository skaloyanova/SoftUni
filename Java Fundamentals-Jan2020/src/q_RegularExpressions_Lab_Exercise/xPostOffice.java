package q_RegularExpressions_Lab_Exercise;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class xPostOffice {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] tokens = sc.nextLine().split("\\|");
        String part1 = tokens[0];
        String part2 = tokens[1];
        String part3 = tokens[2];

        String regexPart1CAPS = "([#$%*&])(?<caps>[A-Z]+)\\1";
        Pattern patternPart1CAPS = Pattern.compile(regexPart1CAPS);
        Matcher matchPart1CAPS = patternPart1CAPS.matcher(part1);

        String caps = "";
        if (matchPart1CAPS.find()) {
            caps = matchPart1CAPS.group("caps");
        }
        Map<Character, Integer> lettersAndLength = new LinkedHashMap<>();

        for (int i = 0; i < caps.length(); i++) {
            char current = caps.charAt(i);
            String patternPart2Length = ".*?" + (int)current + ":(?<length>\\d\\d)";
            Matcher matchPart2Length = Pattern.compile(patternPart2Length).matcher(part2);
            int length = 0;
            if (matchPart2Length.find()) {
                length = Integer.parseInt(matchPart2Length.group("length"));
                lettersAndLength.put(current, length + 1);
            }
        }

//        for (Map.Entry<Character, Integer> entry : lettersAndLength.entrySet()) {
//            String patternPart3Word = "\\s(?<word>" + entry.getKey() + "[^\\s]{" + entry.getValue() + "})\\b";
//            Matcher matchPart3Word = Pattern.compile(patternPart3Word).matcher(part3);
//            if (matchPart3Word.find()) {
//                System.out.println(matchPart3Word.group("word"));
//            }
//        }

        String[] wordsPart3 = part3.split("\\s+");
        for (int i = 0; i < caps.length(); i++) {
            char currentLetter = caps.charAt(i);
            int currentLength = lettersAndLength.get(currentLetter);

            for (String word : wordsPart3) {
                if (word.charAt(0) == currentLetter && word.length() == currentLength) {
                    System.out.println(word);
                }
            }
        }
    }
}
