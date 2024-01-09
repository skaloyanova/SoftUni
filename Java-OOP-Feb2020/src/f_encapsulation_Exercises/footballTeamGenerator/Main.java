package f_encapsulation_Exercises.footballTeamGenerator;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Team> teams = new HashMap<>();

        String command = sc.nextLine();

        while (!"END".equals(command)) {
            String[] split = command.split(";");

            String cmdType = split[0];
            String teamName = split[1];

            try {
                switch (cmdType) {
                    case "f_encapsulation_Exercises.footballTeamGenerator.Team":        //ex. f_encapsulation_Exercises.footballTeamGenerator.Team;Arsenal
                        Team team = new Team(teamName);
                        teams.putIfAbsent(teamName, team);
                        break;
                    case "Add":         //ex. Add;Arsenal;Aaron_Ramsey;95;82;82;89;68
                        validateTeam(teams, teamName);
                        Player player = new Player(split[2], Integer.parseInt(split[3]), Integer.parseInt(split[4]),
                                Integer.parseInt(split[5]), Integer.parseInt(split[6]), Integer.parseInt(split[7]));
                        teams.get(teamName).addPlayer(player);
                        break;
                    case "Remove":      //ex. Remove;Arsenal;Aaron_Ramsey
                        validateTeam(teams, teamName);
                        teams.get(teamName).removePlayer(split[2]);
                        break;
                    case "Rating":      //ex. Rating;Arsenal
                        validateTeam(teams, teamName);
                        System.out.printf("%s - %d%n", teamName, (int) teams.get(teamName).getRating());
                        break;
                }
            } catch (IllegalStateException | IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }

            command = sc.nextLine();
        }
    }

    private static void validateTeam(Map<String, Team> teams, String teamName) {
        if (!teams.containsKey(teamName)) {
            throw new IllegalStateException("f_encapsulation_Exercises.footballTeamGenerator.Team " + teamName + " does not exist.");
        }
    }
}
