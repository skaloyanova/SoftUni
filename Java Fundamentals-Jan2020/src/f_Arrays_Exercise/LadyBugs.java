package f_Arrays_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class LadyBugs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int fieldSize = Integer.parseInt(sc.nextLine());
        int[] initialIndex = Arrays.stream(sc.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int[] field = new int[fieldSize];

        for (int index : initialIndex) {
            if (validIndex(index, field)) {
                field[index] = 1;
            }
        }
        while (true) {
            String input = sc.nextLine();
            if (input.equals("end")) {
                break;
            }
            String[] command = input.split(" ");
            int ladybugIndex = Integer.parseInt(command[0]);
            String ladybugDirection = command[1];
            int ladybugFlyLength = Integer.parseInt(command[2]);

            if (ladybugFlyLength == 0) {
                continue;
            }

            int newIndex;

            if (validIndex(ladybugIndex, field) && field[ladybugIndex] == 1) {
                newIndex = newIndex(ladybugIndex, ladybugDirection, ladybugFlyLength);

                while (true) {
                    if (!validIndex(newIndex, field)) {
                        field[ladybugIndex] = 0;
                        break;
                    } else if (field[newIndex] == 0) {
                        field[newIndex] = 1;
                        field[ladybugIndex] = 0;
                        break;
                    } else if (validIndex(newIndex, field) && field[newIndex] == 1) {
                        newIndex = newIndex(newIndex, ladybugDirection, ladybugFlyLength);
                    }
                }
            }
        }
        // output
        for (int element : field) {
            System.out.print(element + " ");
        }
    }

    private static int newIndex(int ladybugIndex, String ladybugDirection, int ladybugFlyLength) {
        int newIndex = 0;

        if (ladybugDirection.equals("right")) {
            newIndex = ladybugIndex + ladybugFlyLength;

        } else if (ladybugDirection.equals("left")) {
            newIndex = ladybugIndex - ladybugFlyLength;
        }
        return newIndex;
    }

    private static boolean validIndex(int index, int[] arr) {
        return index >= 0 && index < arr.length;
    }
}
