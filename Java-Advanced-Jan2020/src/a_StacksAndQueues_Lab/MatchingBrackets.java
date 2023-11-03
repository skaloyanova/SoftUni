package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class MatchingBrackets {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String expression = sc.nextLine();

        Deque<Integer> bracketIndex = new ArrayDeque<>();

        for (int i = 0; i < expression.length(); i++) {
            char currentChar = expression.charAt(i);
            if (currentChar == '(') {
                bracketIndex.push(i);
            } else if (currentChar == ')') {
                System.out.println(expression.substring(bracketIndex.pop(), i + 1));
            }
        }
    }
}
