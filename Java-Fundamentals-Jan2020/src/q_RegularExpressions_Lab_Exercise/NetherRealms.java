package q_RegularExpressions_Lab_Exercise;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class NetherRealms {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<String> demons = Arrays
                .stream(sc.nextLine().split(","))
                .collect(Collectors.toList());

        for (int i = 0; i < demons.size(); i++) {
            String newDemon = demons.get(i).replaceAll(" ", "");
            demons.set(i, newDemon);
        }

        Collections.sort(demons);

        for (String demon : demons) {
            Pattern healthPattern = Pattern.compile("[^\\d+\\-*/.]");
            Matcher healthMatch = healthPattern.matcher(demon);

            StringBuilder sb = new StringBuilder();
            while (healthMatch.find()) {
                sb.append(healthMatch.group());
            }
            int health = 0;
            for (int i = 0; i < sb.length(); i++) {
                health += sb.charAt(i);
            }

            double damage = 0;
            Matcher damageMatch = Pattern.compile("[-+]?([0-9]+\\.[0-9]+|[0-9]+)").matcher(demon);
            while (damageMatch.find()) {
                damage += Double.parseDouble(damageMatch.group());
            }

            Matcher arithmeticMatch = Pattern.compile("[*/]").matcher(demon);

            while (arithmeticMatch.find()) {
                switch (arithmeticMatch.group()) {
                    case "*":
                        damage *= 2;
                        break;
                    case "/":
                        damage /= 2;
                        break;
                }
            }
            System.out.println(String.format("%s - %d health, %.2f damage", demon, health, damage));
        }
    }
}
