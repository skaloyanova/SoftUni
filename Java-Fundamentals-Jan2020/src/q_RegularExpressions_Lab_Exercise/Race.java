package q_RegularExpressions_Lab_Exercise;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Race {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] participants = sc.nextLine().split(", ");

        String regexName = "[A-Za-z]";
        String regexDistance = "\\d+";
        Pattern patternName = Pattern.compile(regexName);
        Pattern patternDistance = Pattern.compile(regexDistance);

        Map<String, Integer> racers = new LinkedHashMap<>();

        String input = sc.nextLine();

        while (!"end of race".equals(input)) {
            Matcher letters = patternName.matcher(input);
            Matcher digits = patternDistance.matcher(input);

            StringBuilder allLetters = new StringBuilder();
            StringBuilder allDigits = new StringBuilder();

            while (letters.find()) {
                allLetters.append(letters.group());
            }

            String name = allLetters.toString();

            if (!Arrays.asList(participants).contains(name)) {
                input = sc.nextLine();
                continue;
            }

            while (digits.find()) {
                allDigits.append(digits.group());
            }

            int distance = 0;
            for (int i = 0; i < allDigits.length(); i++) {
                distance += Integer.parseInt(String.valueOf(allDigits.charAt(i)));
            }

            racers.putIfAbsent(name, 0);
            racers.put(name, racers.get(name) + distance);

            input = sc.nextLine();
        }

        int[] num = {1};
        racers.entrySet()
                .stream()
                .sorted((d1, d2) -> d2.getValue().compareTo(d1.getValue()))
                .limit(3)
                .forEach(e -> {
                    String rank = "";
                    switch (num[0]) {
                        case 1: rank = "1st";break;
                        case 2: rank = "2nd";break;
                        case 3: rank = "3rd";break;
                    }
                    System.out.println(String.format("%s place: %s", rank, e.getKey()));
                    num[0]++;
                });
    }
}