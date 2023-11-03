package z_Exam_20180827_Retake_archived;

import java.util.*;

public class Agents {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Mission> missions = new HashMap<>();
        Map<String, Agent> agents = new LinkedHashMap<>();

        List<String> agentNamesRegistration = new ArrayList<>();

        // registration
        String input = sc.nextLine();
        while (!"registration".equals(input)) {
            String[] tokens = input.split(":");
            if (tokens.length == 1) {
                agentNamesRegistration.add(tokens[0]);
            } else if (tokens.length == 2){
                missions.put(tokens[0], new Mission(tokens[0], Double.parseDouble(tokens[1])));
            }

            input = sc.nextLine();
        }

        // operation
        input = sc.nextLine();
        while (!"operate".equals(input)) {
            String[] tokens = input.split("->");

            String command = tokens[0];

            switch (command) {
                case "assign": {
                    String agentName = tokens[1];
                    String missionName = tokens[2];
                    if (missions.containsKey(missionName)) {
                        Mission mission = missions.get(missionName);
                        if (agents.containsKey(agentName)) {
                            agents.get(agentName).addMission(mission);
                        } else {
                            Agent agent = new Agent(agentName);
                            agent.addMission(mission);
                            agents.put(agentName, agent);
                        }
                    }
                }
                break;
                case "abort": {
                    String missionName = tokens[1];
                    for (Agent agent : agents.values()) {
                        agent.getMissions().removeIf(e -> e.getName().equals(missionName));
                    }
                }
                break;
                case "change": {
                    String agentName1 = tokens[1];
                    String agentName2 = tokens[2];

                    Set<Mission> agent1 = agents.get(agentName1).getMissions();
                    Set<Mission> agent2 = agents.get(agentName2).getMissions();
                    agents.get(agentName1).setMissions(agent2);
                    agents.get(agentName2).setMissions(agent1);
                }
                break;
            }

            input = sc.nextLine();
        }

        //print
        agents.values().stream()
                .filter(e -> e.getMissions().size() > 0)
                .sorted((f, s) -> Double.compare(s.getTotalRating(), f.getTotalRating()))
                .forEach(a -> {
                    System.out.println(a);
                    a.getMissions().stream()
                            .sorted((f, s) -> Double.compare(s.getRating(), f.getRating()))
                            .forEach(System.out::println);
                });
    }

    private static class Agent {
        private String name;
        private Set<Mission> missions;

        public Agent(String name) {
            this.name = name;
            this.missions = new LinkedHashSet<>();
        }

        public void addMission(Mission mission) {
            missions.add(mission);
        }

        public void removeMission(Mission mission) {
            missions.remove(mission);
        }

        public void setMissions(Set<Mission> missions) {
            this.missions = missions;
        }

        public Set<Mission> getMissions() {
            return missions;
        }

        public double getTotalRating() {
            return missions.stream().map(Mission::getRating).mapToDouble(e -> e).sum();
        }

        public String getName() {
            return name;
        }

        @Override
        public String toString() {
            return String.format("Agent: %s - Total Rating: %.2f", this.name, this.getTotalRating());
        }
    }

    private static class Mission {
        private String name;
        private double rating;

        public Mission(String name, double rating) {
            this.name = name;
            this.rating = rating;
        }

        public String getName() {
            return name;
        }

        public double getRating() {
            return rating;
        }

        @Override
        public String toString() {
            return String.format(" - %s -> %.2f", this.name, this.rating);
        }
    }
}
