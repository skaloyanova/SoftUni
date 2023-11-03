package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class SimpleCalculator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] input = sc.nextLine().split("\\s+");
        Deque<String> expression = new ArrayDeque<>();

        if (input.length == 0) {
            return;
        }

        for (int i = input.length - 1; i >= 0; i--) {
            expression.push(input[i]);
        }

        int result = Integer.parseInt(expression.pop());    //first element
        while (expression.size() > 0) {
            String operator = expression.pop();
            int num = Integer.parseInt(expression.pop());

            if ("+".equals(operator)) {
                result += num;
            } else if ("-".equals(operator)) {
                result -= num;
            }
        }
        System.out.println(result);
    }
}
