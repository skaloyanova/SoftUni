package j_Lists_Exercise;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Train {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> train = Arrays.stream(sc.nextLine().split(" "))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        int wagonCapacity = Integer.parseInt(sc.nextLine());

        while (true) {
            String input = sc.nextLine();
            if (input.equals("end")) {
                break;
            }

            String[] command = input.split(" ");

            if (command.length == 1) {
                int passengers = Integer.parseInt(command[0]);
                addPassengersToWagon(train, passengers, wagonCapacity);
            }
            if (command.length == 2) {
                int passengers = Integer.parseInt(command[1]);
                train.add(passengers);
            }
        }
        System.out.println(train.toString().replaceAll("[\\[\\],]", ""));
    }

    private static void addPassengersToWagon(List<Integer> train, int passengers, int wagonCapacity) {
        for (int i = 0; i < train.size(); i++) {
            int wagonOccupancy = train.get(i);
            int newCapacity = wagonOccupancy + passengers;

            if (newCapacity <= wagonCapacity) {
                train.set(i, newCapacity);
                return;
            }
        }
    }
}
