package z_Exam_20180610_archived;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Genome {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> organisms = new LinkedHashMap<>();

        String gen = sc.nextLine();
        while (!"Stop!".equals(gen)) {
            String regex = "(?<name>[a-z!@#$?]+)=(?<len>[0-9]+)--(?<cnt>[0-9]+)<<(?<org>.+)";
            Matcher validGen = Pattern.compile(regex).matcher(gen);

            if (validGen.find()) {
                String name = validGen.group("name");
                int length = Integer.parseInt(validGen.group("len"));
                int count = Integer.parseInt(validGen.group("cnt"));
                String organism = validGen.group("org");

                name = name.replaceAll("[!@#$?]", "");

                if (name.length() == length) {
                    organisms.putIfAbsent(organism, 0);
                    organisms.put(organism, organisms.get(organism) + count);
                }
            }

            gen = sc.nextLine();
        }

        // print
        organisms.entrySet().stream()
                .sorted((f,s) -> Integer.compare(s.getValue(), f.getValue()))
                .forEach((e) -> System.out.println(e.getKey() + " has genome size of " + e.getValue()));
    }
}
