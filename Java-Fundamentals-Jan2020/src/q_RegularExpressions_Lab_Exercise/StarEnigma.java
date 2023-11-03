package q_RegularExpressions_Lab_Exercise;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class StarEnigma {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        List<String> attachedPlanets = new ArrayList<>();
        List<String> destroyedPlanets = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String message = sc.nextLine();
            int key = 0;
            for (int j = 0; j < message.length(); j++) {
                char current = message.toLowerCase().charAt(j);
                if (current == 's' || current == 't' || current == 'a' || current == 'r') {
                    key++;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < message.length(); j++) {
                char current = message.charAt(j);
                String newChar = "" + (char) (current - key);
                sb.append(newChar);
            }
            String decrypted = sb.toString();

            String regex = "[^@\\-!:>]*@(?<planet>[A-Za-z]+)[^@\\-!:>]*:(?<pop>\\d+)[^@\\-!:>]*!(?<attack>[AD])!" +
                    "[^@\\-!:>]*->(?<count>\\d+)";
            Pattern pattern = Pattern.compile(regex);
            Matcher matcher = pattern.matcher(decrypted);

            if (matcher.find()) {
                String planet = matcher.group("planet");
                //int population = Integer.parseInt(matcher.group("pop"));
                String attackType = matcher.group("attack");
                //int soldierCnt = Integer.parseInt(matcher.group("count"));

                if ("A".equals(attackType)) {
                    attachedPlanets.add(planet);
                } else {
                    destroyedPlanets.add(planet);
                }
            }
        }
        Collections.sort(attachedPlanets);
        Collections.sort(destroyedPlanets);
        System.out.println("Attacked planets: " + attachedPlanets.size());
        for (String planet : attachedPlanets) {
            System.out.println("-> " + planet);
        }
        System.out.println("Destroyed planets: " + destroyedPlanets.size());
        for (String planet : destroyedPlanets) {
            System.out.println("-> " + planet);
        }
    }
}
