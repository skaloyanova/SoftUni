package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class BrowserHistoryUpgrade {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Deque<String> sites = new ArrayDeque<>();
        Deque<String> forward = new ArrayDeque<>();

        while (true) {
            String command = sc.nextLine();
            switch (command) {
                case "back":
                    if (sites.size() <= 1) {
                        System.out.println("no previous URLs");
                        break;
                    }
                    String removed = sites.pop();
                    forward.push(removed);
                    System.out.println(sites.peek());
                    break;
                case "forward":
                    if (forward.isEmpty()) {
                        System.out.println("no next URLs");
                        break;
                    }
                    String restore = forward.pop();
                    sites.push(restore);
                    System.out.println(restore);
                    break;
                case "Home":
                    return;
                default:
                    sites.push(command);
                    System.out.println(command);
                    forward.clear();
                    break;
            }
        }
    }
}
