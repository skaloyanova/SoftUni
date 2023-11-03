package Final2019_12_07_gr2;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class MessageTranslator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Pattern pattern = Pattern.compile("!(?<command>[A-Z][a-z]{2,})!:\\[(?<msg>[A-Za-z]{8,})\\]");

        for (int i = 0; i < n; i++) {
            String message = sc.nextLine();
            Matcher matcher = pattern.matcher(message);

            if (matcher.find()) {
                String command = matcher.group("command");
                String msg = matcher.group("msg");
                System.out.print(command + ":");
                for (int j = 0; j < msg.length(); j++) {
                    System.out.printf(" %d",(int)msg.charAt(j));
                }
                System.out.println();
            } else {
                System.out.println("The message is invalid");
            }
        }
    }
}
