package f_Arrays_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class KaminoFactory {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        int currentSequence = 0;
        int bestSequence = 0;
        int bestLength = 0;
        int bestStartIndex = Integer.MAX_VALUE;
        int bestSum = 0;
        int[] bestArray = new int[n];

        while (true) {
            String command = sc.nextLine();
            if (command.equals("Clone them!")) {
                break;
            }

            int[] sequence = Arrays.stream(command.split("!+")).mapToInt(Integer::parseInt).toArray();

            currentSequence++;

            int startIndex = -1;
            int maxLength = 0;
            int sum = 0;

            for (int i = 0; i < sequence.length; i++) {
                int length = 1;
                sum += sequence[i];
                if (sequence[i] != 1) {
                    continue;
                }
                for (int j = i + 1; j < sequence.length; j++) {
                    if (sequence[i] == sequence[j]) {
                        length++;
                        if (length > maxLength) {
                            maxLength = length;
                            startIndex = i;
                        }
                    } else {
                        break;
                    }
                }
            }


            if (maxLength > bestLength) {
                bestLength = maxLength;
                bestStartIndex = startIndex;
                bestSum = sum;
                bestSequence = currentSequence;
                bestArray = sequence;
            } else if (maxLength == bestLength) {
                if (startIndex < bestStartIndex) {
                    bestStartIndex = startIndex;
                    bestSum = sum;
                    bestSequence = currentSequence;
                    bestArray = sequence;
                } else if (startIndex == bestStartIndex) {
                    if (sum > bestSum) {
                        bestSum = sum;
                        bestSequence = currentSequence;
                        bestArray = sequence;
                    }
                }
            }
        }


        System.out.println(String.format("Best DNA sample %d with sum: %d.", bestSequence, bestSum));
        for(int element : bestArray) {
            System.out.print(element + " ");
        }
    }
}