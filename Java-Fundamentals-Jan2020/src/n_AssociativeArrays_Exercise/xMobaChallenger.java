package n_AssociativeArrays_Exercise;

import java.util.*;

public class xMobaChallenger {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String,Map<String,Integer>> pool = new HashMap<>();

        String input = sc.nextLine();

        while (!"Season end".equals(input)) {
            String[] tokens = input.split("\\s+");
            //0      1   2       3  4
            //player -> position -> skill
            //player vs player

            String choice = tokens[1];

            switch (choice) {
                case "->":
                    String player = tokens[0];
                    String position = tokens[2];
                    int skill = Integer.parseInt(tokens[4]);

                    pool.putIfAbsent(player, new HashMap<>());
                    pool.get(player).putIfAbsent(position, 0);
                    int prevSkill = pool.get(player).get(position);
                    pool.get(player).put(position, Math.max(prevSkill, skill));

                    break;
                case "vs":
                    String player1 = tokens[0];
                    String player2 = tokens[2];

                    if (!pool.containsKey(player1) || !pool.containsKey(player2)) {
                        break;
                    }

                    List<String> player1Skills = new ArrayList<>(pool.get(player1).keySet());
                    List<String> player2Skills = new ArrayList<>(pool.get(player2).keySet());

                    int player1Points = pool.get(player1).values().stream().mapToInt(x -> x).sum();
                    int player2Points = pool.get(player2).values().stream().mapToInt(x -> x).sum();

                    boolean match = false;
                    for (String player1Skill : player1Skills) {
                        for (String player2Skill : player2Skills) {
                            if (player1Skill.equals(player2Skill)) {
                                match = true;
                                break;
                            }
                        }
                    }

                    if (match && player1Points > player2Points) {
                        pool.remove(player2);
                    }
                    if (match && player2Points > player1Points) {
                        pool.remove(player1);
                    }
                    break;
            }

            input = sc.nextLine();
        }

        //output
        pool.entrySet()
                .stream()
                .sorted((p1,p2) -> {
                    int p1points = p1.getValue().values().stream().mapToInt(x -> x).sum();
                    int p2points = p2.getValue().values().stream().mapToInt(x -> x).sum();

                    int res = Integer.compare(p2points, p1points);
                    if (res == 0) {
                        res = p1.getKey().compareTo(p2.getKey());
                    }
                    return res;
                })
                .forEach(e -> {
                    int sum = e.getValue().values().stream().mapToInt(x -> x).sum();
                    System.out.println(String.format("%s: %d skill", e.getKey(), sum));

                    e.getValue()
                            .entrySet()
                            .stream()
                            .sorted((p1, p2) -> {
                                int res = p2.getValue().compareTo(p1.getValue());
                                if (res == 0) {
                                    res = p1.getKey().compareTo(p2.getKey());
                                }
                                return res;
                            })
                            .forEach(s -> System.out.println(String.format("- %s <::> %d", s.getKey(), s.getValue())));
                });
    }
}
