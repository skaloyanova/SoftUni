package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.BiFunction;

public class AppliedArithmetics {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] numbers = Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        BiFunction<String, Integer, Integer> commandFunc = (cmd, num) -> {
            switch (cmd) {
                case "add":
                    return num + 1;
                case "multiply":
                    return num * 2;
                case "subtract":
                    return num - 1;
            }
            return num;
        };

        String command = sc.nextLine().toLowerCase().trim();
        while (!"end".equals(command)) {

            if ("print".equals(command)) {
                Arrays.stream(numbers).forEach(e -> System.out.print(e + " "));
                System.out.println();
            } else {
                String finalCommand = command;
                numbers = Arrays.stream(numbers).map(e -> commandFunc.apply(finalCommand, e)).toArray();
            }

            command = sc.nextLine();
        }
    }
}
