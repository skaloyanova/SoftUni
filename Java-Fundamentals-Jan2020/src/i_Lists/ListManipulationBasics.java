package i_Lists;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class ListManipulationBasics {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<Integer> numbersList = Arrays.stream(sc.nextLine().split(" "))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        while (true) {
            String input = sc.nextLine();

            if (input.equals("end")) {
                break;
            }
            String[] command = input.split(" ");

            switch (command[0]) {
                case "Add":
                    numbersList.add(Integer.valueOf(command[1])); break;
                case "Remove":
                    numbersList.remove(Integer.valueOf(command[1])); break;
                case "RemoveAt":
                    numbersList.remove(Integer.parseInt(command[1])); break;
                case "Insert":
                    numbersList.add(Integer.parseInt(command[2]), Integer.valueOf(command[1])); break;
            }
        }

        // print List
        for (Integer num : numbersList) {
            System.out.print(num + " ");
        }
    }
}
