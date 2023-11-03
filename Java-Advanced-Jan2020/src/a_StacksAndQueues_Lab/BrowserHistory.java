package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class BrowserHistory {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Deque<String> history = new ArrayDeque<>();

        while (true) {
            String url = sc.nextLine();

            switch (url) {
                case "Home": return;
                case "back":
                    if (history.size() <= 1) {
                        System.out.println("no previous URLs");
                    } else {
                        history.pop();
                        System.out.println(history.peek());

                    }
                    break;
                default:
                    history.push(url);
                    System.out.println(history.peek());
                    break;
            }
        }
    }
}
