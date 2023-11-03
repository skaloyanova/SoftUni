package q_RegularExpressions_Lab_Exercise;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class xWinningTicket {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<String> tickets = Arrays
                .stream(sc.nextLine().split(",\\s+"))
                .collect(Collectors.toList());

        for (int i = 0; i < tickets.size(); i++) {
            if (tickets.get(i).contains(" ")) {
                String newTicket = tickets.get(i).replaceAll(" ", "");
                tickets.set(i, newTicket);
            }
        }

        String validTicketRegex = "\\${6,}|@{6,}|#{6,}|\\^{6,}";
        Pattern pattern = Pattern.compile(validTicketRegex);

        for (String ticket : tickets) {

            if (ticket.length() != 20) {
                System.out.println("invalid ticket");
                continue;
            }

            String leftSide = ticket.substring(0, 10);
            String rightSide = ticket.substring(10);

            Matcher leftMatch = pattern.matcher(leftSide);
            Matcher rightMatch = pattern.matcher(rightSide);

            if (leftMatch.find() && rightMatch.find()) {
                int leftCnt = leftMatch.group().length();
                int rightCnt = rightMatch.group().length();

                int min = Math.min(leftCnt, rightCnt);
                char symbol = leftMatch.group().charAt(0);

                if (min == 10) {
                    System.out.println(String.format("ticket \"%s\" - %d%c Jackpot!", ticket, min, symbol));
                } else {
                    System.out.println(String.format("ticket \"%s\" - %d%c", ticket, min, symbol));
                }

            } else {
                System.out.println(String.format("ticket \"%s\" - no match", ticket));
            }
        }
    }
}
