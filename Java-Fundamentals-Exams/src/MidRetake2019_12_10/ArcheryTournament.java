package MidRetake2019_12_10;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class ArcheryTournament {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> targets = Arrays.stream(sc.nextLine().split("\\|"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        int points = 0;
        String input = sc.nextLine();

        while (!"Game over".equals(input)) {
            String[]tokens = input.split("\\s+");

            switch (tokens[0]) {
                case "Shoot":
                    String[] details = tokens[1].split("@");

                    String direction = details[0];
                    int startIndex = Integer.parseInt(details[1]);
                    int length = Integer.parseInt(details[2]);
                    length = length % targets.size();

                    if (startIndex < 0 || startIndex >= targets.size()) {
                        break;
                    }

                    int targetIndex = startIndex;
                    if ("Right".equals(direction)) {
                        targetIndex = (startIndex + length) % targets.size();
                    } else if ("Left".equals(direction)) {
                        targetIndex = startIndex - length;
                        if (targetIndex < 0) {
                            targetIndex += targets.size();
                        }
                    }

                    int targetValue = targets.get(targetIndex);

                    if (targetValue < 5) {
                        points += targetValue;
                        targets.set(targetIndex, 0);
                    } else {
                        points += 5;
                        targets.set(targetIndex, targetValue - 5);
                    }

                    break;
                case "Reverse":
                    Collections.reverse(targets);
                    break;
            }


            input = sc.nextLine();
        }

        //output
        for (int i = 0; i < targets.size(); i++) {
            String delimiter = " - ";
            if (i == targets.size() - 1) {
                delimiter = "";
            }
            System.out.print(targets.get(i) + delimiter);
        }

        System.out.println();
        System.out.printf("Iskren finished the archery tournament with %d points!", points);
    }
}
