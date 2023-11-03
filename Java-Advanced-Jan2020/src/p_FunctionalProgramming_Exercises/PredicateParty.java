package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class PredicateParty {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<String> guests = Arrays.stream(sc.nextLine().split("\\s")).collect(Collectors.toList());

        String command = sc.nextLine();
        while (!"Party!".equals(command)) {
            String[] tokens = command.split("\\s+");
            String doubleRemove = tokens[0];
            String startEndLength = tokens[1];
            String text = tokens[2];

            Predicate<String> predicate = createPredicate(startEndLength, text);

            if ("Remove".equals(doubleRemove)) {
                guests.removeIf(predicate);

            } else if ("Double".equals(doubleRemove)) {
                List<String> guestsToAdd = guests.stream()
                        .filter(predicate)
                        .collect(Collectors.toList());
                guests.addAll(guestsToAdd);
            }

            command = sc.nextLine();
        }

        guests.sort(Comparator.naturalOrder());

        if (guests.size() == 0) {
            System.out.println("Nobody is going to the party!");
        } else {
            System.out.println(String.join(", ", guests) + " are going to the party!");
        }
    }

    private static Predicate<String> createPredicate(String startEndLength, String text) {
        Predicate<String> filter = null;
        switch (startEndLength) {
            case "StartsWith":
                return x -> {
                    if (x.length() < text.length()) {
                        return false;
                    } else {
                        return x.startsWith(text);
                    }
                };
            case "EndsWith":
                return x -> {
                    if (x.length() < text.length()) {
                        return false;
                    } else {
                        return x.endsWith(text);
                    }
                };
            case "Length":
                return x -> x.length() == Integer.parseInt(text);
            default:
                return x -> false;
        }
    }
}
