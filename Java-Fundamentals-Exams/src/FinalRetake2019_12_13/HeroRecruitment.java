package FinalRetake2019_12_13;

import java.util.*;

public class HeroRecruitment {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, List<String>> heroes = new HashMap<>();

        String input = sc.nextLine();

        while (!"End".equals(input)) {
            String[] tokens = input.split("\\s+");
            String command = tokens[0];
            String heroName = tokens[1];
            String spell = "";
            if (tokens.length > 2) {
                spell = tokens[2];
            }

            switch (command) {
                case "Enroll":
                    if (heroes.containsKey(heroName)) {
                        System.out.println(heroName + " is already enrolled.");
                    } else {
                        heroes.put(heroName, new ArrayList<>());
                    }
                    break;
                case "Learn":
                    if (heroes.containsKey(heroName)) {
                        if (heroes.get(heroName).contains(spell)) {
                            System.out.println(String.format("%s has already learnt %s.", heroName, spell));
                        } else {
                            heroes.get(heroName).add(spell);
                        }
                    } else {
                        System.out.println(heroName + " doesn't exist.");
                    }
                    break;
                case "Unlearn":
                    if (heroes.containsKey(heroName)) {
                        if (heroes.get(heroName).contains(spell)) {
                            heroes.get(heroName).remove(spell);
                        } else {
                            System.out.println(String.format("%s doesn't know %s.", heroName, spell));
                        }
                    } else {
                        System.out.println(heroName + " doesn't exist.");
                    }
                    break;
            }

            input = sc.nextLine();
        }

        //output
        System.out.println("Heroes:");
        heroes.entrySet()
                .stream()
                .sorted((s1,s2) -> {
                    int res = s2.getValue().size() - s1.getValue().size();
                    if (res == 0) {
                        res = s1.getKey().compareTo(s2.getKey());
                    }
                    return res;
                })
                .forEach(e -> System.out.println(String.format("== %s: %s",
                        e.getKey(), String.join(", ", e.getValue()))));
    }
}
