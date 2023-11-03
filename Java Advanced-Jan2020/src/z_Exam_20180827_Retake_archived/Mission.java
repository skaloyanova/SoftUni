package z_Exam_20180827_Retake_archived;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Mission {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> completed = new HashMap<>();
        Map<String, Integer> failed = new HashMap<>();

        String text = sc.nextLine();
        while (!"Decrypt".equals(text)) {

            String regexMission = ".*M.*I.*S.*S.*I.*O.*N.*";
            Matcher matcher = Pattern.compile(regexMission).matcher(text);

            if (!matcher.find()) {
                text = sc.nextLine();
                continue;
            }

            char[] chars = text.toCharArray();

            StringBuilder missionName = new StringBuilder();
            int rating = 0;

            for (char symbol : chars) {
                if (Character.isLowerCase(symbol)) {
                    missionName.append(symbol);
                }
                if (Character.isDigit(symbol)) {
                    rating += Character.getNumericValue(symbol);
                }
            }

            if (text.contains("C")) {
                completed.put(missionName.toString(), rating);
            }
            if (text.contains("X")) {
                failed.put(missionName.toString(), rating);
            }

            text = sc.nextLine();
        }

        completed.entrySet().stream()
                .sorted((f,s) -> s.getValue() - f.getValue())
                .limit(1)
                .forEach(e -> System.out.println(String.format("Completed mission %s with rating: %d"
                        , e.getKey(), e.getValue())));

        failed.entrySet().stream()
                .sorted((f,s) -> s.getValue() - f.getValue())
                .limit(1)
                .forEach(e -> System.out.println(String.format("Failed Mission %s with rating: %d"
                        , e.getKey(), e.getValue())));
    }
}
