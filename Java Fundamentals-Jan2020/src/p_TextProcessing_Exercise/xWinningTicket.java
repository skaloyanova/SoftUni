package p_TextProcessing_Exercise;

import java.util.Scanner;

public class xWinningTicket {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] tickets = sc.nextLine().split("\\s*,\\s+");
        System.out.println(String.join("-", tickets));

        for (String ticket : tickets) {
            if (ticket.length() != 20) {
                System.out.println("invalid ticket");
                continue;
            }

            String leftHalf = ticket.substring(0, 10);
            String rightHalf = ticket.substring(10);

            String winLeft = maxSeqSym(leftHalf);
            String winRight = maxSeqSym(rightHalf);

            if (winLeft.isEmpty() || winRight.isEmpty()) {
                System.out.println(String.format("ticket \"%s\" - no match", ticket));
                continue;
            }
            int winLeftNum = Integer.parseInt(String.valueOf(winLeft.substring(0, winLeft.length() - 1)));
            char winLeftSym = winLeft.charAt(winLeft.length() - 1);
            int winRightNum = Integer.parseInt(String.valueOf(winRight.substring(0, winRight.length() - 1)));
            char winRightSym = winRight.charAt(winRight.length() - 1);

            if (winLeftSym != winRightSym) {
                System.out.println(String.format("ticket \"%s\" - no match", ticket));
            } else if (winLeftNum == 10 && winRightNum == 10) {
                System.out.println(String.format("ticket \"%s\" - %d%s Jackpot!", ticket, winLeftNum, winLeftSym));
            } else {
                System.out.println(String.format("ticket \"%s\" - %d%s",
                        ticket, Math.min(winLeftNum, winRightNum), winLeftSym));
            }
        }
    }

    private static String maxSeqSym(String text) {
        String[] symbols = {"@", "#", "$", "^"};

        String result = "";
        for (String symbol : symbols) {
            int num = numOfSubsequentSymbols(text, symbol);
            if (num >= 6) {
                result = "" + num + symbol;
            }
        }
        return result;
    }

    private static int numOfSubsequentSymbols(String text, String symbol) {
        int index = text.indexOf(symbol);

        if (index < 0) {
            return 0;
        }
        StringBuilder pattern = new StringBuilder();
        pattern.append(symbol);

        int maxPatternSize = 0;
        for (int i = index + 1; i < text.length(); i++) {
            String current = "" + text.charAt(i);
            if (symbol.equals(current)) {
                pattern.append(current);
            } else {
                if (pattern.length() > maxPatternSize) {
                    maxPatternSize = pattern.length();
                }
                pattern.setLength(0);
            }
        }
        if (pattern.length() > maxPatternSize) {
            maxPatternSize = pattern.length();
        }
        return maxPatternSize;
    }
}
