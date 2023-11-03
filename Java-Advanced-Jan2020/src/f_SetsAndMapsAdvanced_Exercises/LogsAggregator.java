package f_SetsAndMapsAdvanced_Exercises;

import java.util.*;

public class LogsAggregator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, Integer> userDur = new TreeMap<>();
        Map<String, Set<String>> userIP = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String[] line = sc.nextLine().split("\\s+");
            String ip = line[0];
            String user = line[1];
            int duration = Integer.parseInt(line[2]);

            if (!userDur.containsKey(user)) {
                userDur.put(user, 0);
                userIP.put(user, new TreeSet<>());
            }
            userDur.put(user, userDur.get(user) + duration);
            userIP.get(user).add(ip);
        }

        userDur.forEach((u,d) -> System.out.println(String.format("%s: %d %s", u, d, userIP.get(u))));
    }
}
