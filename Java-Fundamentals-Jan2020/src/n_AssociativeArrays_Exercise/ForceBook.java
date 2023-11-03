package n_AssociativeArrays_Exercise;

import java.util.*;

public class ForceBook {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        HashMap<String, List<String>> force = new HashMap<>();

        String input = sc.nextLine();
        while (!"Lumpawaroo".equals(input)) {
            String user = "";
            String side = "";
            String operand = "";

            if (input.contains(" | ")) {
                String[] tokens = input.split(" \\| ");
                side = tokens[0];
                user = tokens[1];
                operand = "|";

            } else if (input.contains(" -> ")) {
                String[] tokens = input.split(" -> ");
                user = tokens[0];
                side = tokens[1];
                operand = "->";
            }

            force.putIfAbsent(side, new ArrayList<>());

            String currentUserSide = returnUserSide(force, user);

            switch (operand) {
                case "|":
                    if (currentUserSide == null) {
                        force.get((side)).add(user);
                    }
                    break;
                case "->":
                    if (currentUserSide != null) {
                        force.get(currentUserSide).remove(user);
                    }
                    force.get((side)).add(user);
                    System.out.println(String.format("%s joins the %s side!", user, side));
                    break;
            }

            input = sc.nextLine();
        }

        force.entrySet().stream()
                .filter(e -> e.getValue().size() > 0)
                .sorted((e1,e2) -> {
                    int res = Integer.compare(e2.getValue().size(), e1.getValue().size());
                    if (res == 0) {
                        res = e1.getKey().compareTo(e2.getKey());
                    }
                    return res;
                })
                //Variant 1
//                .forEach(e -> {
//                    System.out.println(String.format("Side: %s, Members: %d", e.getKey(), e.getValue().size()));
//                    e.getValue().stream()
//                            .sorted(String::compareTo)
//                            .forEach(v -> System.out.println("! " + v));
//                });
                //Variant 2
                .map(e -> getOutputString(e))
                .forEach(e -> System.out.println(e));
    }

    private static String getOutputString(Map.Entry<String, List<String>> entry) {
        Collections.sort(entry.getValue());
        String membersString = "! " + String.join("\n! ", entry.getValue());
        return String.format("Side: %s, Members: %d%n%s", entry.getKey(), entry.getValue().size(),membersString);

    }

    private static String returnUserSide(Map<String, List<String>> force, String user) {
        for (Map.Entry<String, List<String>> entry : force.entrySet()) {
            if (entry.getValue().contains(user)) {
                return entry.getKey();
            }
        }
        return null;
    }
}
