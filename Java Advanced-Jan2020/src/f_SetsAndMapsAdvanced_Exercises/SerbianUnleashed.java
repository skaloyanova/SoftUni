package f_SetsAndMapsAdvanced_Exercises;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SerbianUnleashed {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        final String REGEX = "^(?<singer>\\w+ ?\\w+? ?\\w+?) @(?<venue>\\w+ ?\\w+? ?\\w+?) (?<price>[0-9]+) (?<count>[0-9]+)";
        Pattern pattern = Pattern.compile(REGEX);

        Map<String,Map<String,Integer>> data = new LinkedHashMap<>();
        //Map <venue, Map <singer, money>>

        String line = sc.nextLine();
        while (!"End".equals(line)) {
            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                String singer = matcher.group("singer");
                String venue = matcher.group("venue");
                int price = Integer.parseInt(matcher.group("price"));
                int count = Integer.parseInt(matcher.group("count"));

                int money = price * count;

                data.putIfAbsent(venue, new LinkedHashMap<>());
                data.get(venue).putIfAbsent(singer,0);
                data.get(venue).put(singer, data.get(venue).get(singer) + money);
            }

            line = sc.nextLine();
        }

        //print
        data.forEach((k,v) -> {
            System.out.println(k);
            v.entrySet().stream()
                    .sorted((m1,m2) -> m2.getValue().compareTo(m1.getValue()))
                    .forEach(e -> System.out.println(String.format("#  %s -> %d", e.getKey(), e.getValue())));
        });
    }
}
