package b_StacksAndQueues_Exercises;

import java.util.ArrayDeque;
import java.util.Scanner;

public class InfixToPostfix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(" ");

        ArrayDeque<String> operators = new ArrayDeque<>();
        StringBuilder postfix = new StringBuilder();

        for (String s : input) {

            if (operators.size() == 0) {
                if ("+-*/()".contains(s)){
                    operators.push(s);
                } else {
                    postfix.append(s).append(" ");
                }
                continue;
            }

            switch (s) {
                case "+":
                case "-":
                    if (!operators.peek().equals("(")) {
                        postfix.append(operators.pop()).append(" ");
                    }
                    operators.push(s);
                    break;
                case "*":
                case "/":
                    if (operators.peek().equals("*") || operators.peek().equals("/")) {
                        postfix.append(operators.pop()).append(" ");
                    }
                    operators.push(s);
                    break;
                case "(":
                    operators.push(s);
                    break;
                case ")":
                    postfix.append(operators.pop()).append(" ");
                    operators.pop();
                    break;
                default:
                    postfix.append(s).append(" ");
                    break;
            }
        }
        while (operators.size() > 0) {
            postfix.append(operators.pop()).append(" ");
        }
        System.out.println(postfix);
    }
}
