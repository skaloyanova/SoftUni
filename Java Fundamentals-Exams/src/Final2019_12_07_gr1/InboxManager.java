package Final2019_12_07_gr1;

import java.util.*;

public class InboxManager {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, List<String>> users = new HashMap<>();

        String command = sc.nextLine();

        while (!"Statistics".equals(command)) {
            String[] tokens = command.split("->");
            String action = tokens[0];
            String userName = tokens[1];

            switch (tokens[0]) {
                case "Add":
                    if (users.containsKey(userName)) {
                        System.out.println(userName + " is already registered");
                    } else {
                        users.put(userName, new ArrayList<>());
                    }
                    break;
                case "Send":
                    String message = tokens[2];
                    if (users.containsKey(userName)) {
                        users.get(userName).add(message);
                    }
                    break;
                case "Delete":
                    if (users.containsKey(userName)) {
                        users.remove(userName);
                    } else {
                        System.out.println(userName + " not found!");
                    }
                    break;
            }

            command = sc.nextLine();
        }
        System.out.println("Users count: " + users.size());
        users.entrySet()
                .stream()
                .sorted((u1,u2) -> {
                    int res = u2.getValue().size() - u1.getValue().size();
                    if (res == 0) {
                        res = u1.getKey().compareTo(u2.getKey());
                    }
                    return res;
                })
                .forEach(e -> {
                    System.out.println(e.getKey());
                    e.getValue()
                            .forEach(v -> System.out.println("- " + v));
                });
    }
}
