package MidRetake2020_04_07;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class MovingTarget {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> targets = Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        String input = sc.nextLine();

        while (!"End".equals(input)) {
            String[] tokens = input.split("\\s+");

            String command = tokens[0];
            int index = Integer.parseInt(tokens[1]);

            switch(command) {
                case "Shoot":
                    if (notValidIndex(targets, index)) {
                        break;
                    }
                    int power = Integer.parseInt(tokens[2]);
                    int newPower = targets.get(index) - power;

                    if (newPower > 0) {
                        targets.set(index, newPower);
                    } else {
                        targets.remove(index);
                    }

                    break;
                case "Add":
                    if (notValidIndex(targets, index)) {
                        System.out.println("Invalid placement!");
                        break;
                    }

                    int value = Integer.parseInt(tokens[2]);
                    targets.add(index, value);

                    break;
                case "Strike":
                    int radius = Integer.parseInt(tokens[2]);
                    int startIndex = index - radius;
                    int endIndex = index + radius;

                    if (notValidIndex(targets, startIndex) || notValidIndex(targets, endIndex)) {
                        System.out.println("Strike missed!");
                        break;
                    }

                    for (int i = 0; i <= radius * 2; i++) {
                        targets.remove(startIndex);
                    }

                    break;
            }

            input = sc.nextLine();
        }

        //output
        for (int i = 0; i < targets.size(); i++) {
            String delimiter = "|";
            if (i == targets.size() - 1) {
                delimiter = "";
            }
            System.out.print(targets.get(i) + delimiter);
        }
    }

    private static boolean notValidIndex(List<Integer> targets, int index) {
        return index < 0 || index >= targets.size();
    }
}
