package l_ObjectsAndClasses_Exercise.xTeamworkProjectsNOTwORKING;

import java.util.*;

public class TeamProject {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, List<String>> teams = new TreeMap<>();

        //create teams
        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("-");
            String user = tokens[0];
            String team = tokens[1];

            boolean userExists = false;
            for (List<String> u : teams.values()) {
                if (u.contains(user)) {
                    System.out.println(user + " cannot create another team!");
                    userExists = true;
                    break;
                }
            }

            if (teams.containsKey(team)) {
                System.out.printf("Team %s was already created!%n", team);
            } else if (!userExists) {
                teams.put(team, new ArrayList<>(Arrays.asList(user)));
                System.out.printf("Team %s has been created by %s!%n", team, user);
            }
        }

        //add users to teams
        String command = sc.nextLine();

        while (!"end of assignment".equals(command)) {
            String[] tokens = command.split("->");
            String user = tokens[0];
            String team = tokens[1];

            if (!teams.containsKey(team)) {
                System.out.printf("Team %s does not exist!%n", team);
                command = sc.nextLine();
                continue;
            }

            boolean userExists = false;
            for (List<String> u : teams.values()) {
                if (u.contains(user)) {
                    System.out.printf("Member %s cannot join team %s!%n", user, team);
                    userExists = true;
                    break;
                }
            }

            if (!userExists) {
                teams.get(team).add(user);
            }

            command = sc.nextLine();
        }

        //output
        for (Map.Entry<String, List<String>> entry : teams.entrySet()) {
            if (entry.getValue().size() != 1) {
                System.out.println(entry.getKey());
                System.out.println("- " + entry.getValue().get(0));
                entry.getValue().stream()
                        .skip(1)
                        .sorted()
                        .forEach(e -> System.out.println("-- " + e));
//                for (int i = 1; i < entry.getValue().size(); i++) {
//                    System.out.println("-- " + entry.getValue().get(i));
//                }
            }
        }

        System.out.println("Teams to disband:");
        for (Map.Entry<String, List<String>> entry : teams.entrySet()) {
            if (entry.getValue().size() == 1) {
                System.out.println(entry.getKey());
            }
        }
    }
}
