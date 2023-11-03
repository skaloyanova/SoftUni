package b_StacksAndQueues_Exercises;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class BalancedParenthesis {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String expression = sc.nextLine();

        Deque<String> openingBrackets = new ArrayDeque<>();

        for (int i = 0; i < expression.length(); i++) {
            String currentChar = String.valueOf(expression.charAt(i));

            switch (currentChar) {
                case "(":
                case "[":
                case "{":
                    openingBrackets.push(currentChar);
                    break;
                case ")":
                case "]":
                case "}":
                    if (openingBrackets.isEmpty()) {
                        System.out.println("NO");
                        return;
                    }
                    checkMatchingBracket(openingBrackets, currentChar);
                    break;
            }
        }
        if (openingBrackets.isEmpty()) {
            System.out.println("YES");
        } else {
            System.out.println("NO");
        }
    }

    private static void checkMatchingBracket(Deque<String> openingBrackets, String closingBracket) {
        String matchingOpenBracket = "";
        switch (closingBracket) {
            case ")": matchingOpenBracket = "("; break;
            case "]": matchingOpenBracket = "["; break;
            case "}": matchingOpenBracket = "{"; break;
        }

        String lastOpenBracket = openingBrackets.peek();
        if (matchingOpenBracket.equals(lastOpenBracket)) {
            openingBrackets.pop();
        }
    }
}
