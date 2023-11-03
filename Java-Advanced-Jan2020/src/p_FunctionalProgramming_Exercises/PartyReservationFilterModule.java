package p_FunctionalProgramming_Exercises;

import java.util.*;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class PartyReservationFilterModule {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<String> invitations = Arrays.stream(sc.nextLine().split("\\s+")).collect(Collectors.toList());
        Map<String, Predicate<String>> predicates = new HashMap<>();

        String input = sc.nextLine();
        while (!"Print".equals(input)) {
            String[] tokens = input.split(";");
            String command = tokens[0];         // "Add filter", "Remove filter"
            String filterType = tokens[1];      // "Starts with", "Ends with", "Length", "Contains"
            String filterParam = tokens[2];

            String filterTP = filterType + filterParam;
            Predicate<String> predicate = createPredicate(filterType, filterParam);

            if ("Add filter".equals(command)) {
                predicates.put(filterTP, predicate);
            } else if ("Remove filter".equals(command)) {
                predicates.remove(filterTP);
            }

            input = sc.nextLine();
        }

        invitations.stream()
                .filter(predicates.values().stream().reduce(x -> true, Predicate::and))
                .forEach(e -> System.out.print(e + " "));

    }

    private static Predicate<String> createPredicate(String filterType, String filterParam) {
        Predicate<String> filter = x -> false;

        switch (filterType) {
            case "Starts with":
                filter = x -> x.startsWith(filterParam);
                break;
            case "Ends with":
                filter = x -> x.endsWith(filterParam);
                break;
            case "Contains":
                filter = x -> x.contains(filterParam);
                break;
            case "Length":
                filter = x -> x.length() == Integer.parseInt(filterParam);
                break;
        }

        return filter.negate();
    }
}
