package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class AnonymousThreat {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s+");
        ArrayList<String> data = new ArrayList<>(Arrays.asList(input));

        while (true) {
            String command = sc.nextLine();
            if ("3:1".equals(command)) {
                break;
            }

            String[] tokens = command.trim().split("\\s+");
            String action = tokens[0];

            if ("merge".equals(action)) {
                int startIndex = Integer.parseInt(tokens[1]);
                int endIndex = Integer.parseInt(tokens[2]);

                merge(data, startIndex, endIndex);

            } else if ("divide".equals(action)) {
                int index = Integer.parseInt(tokens[1]);
                int partitions = Integer.parseInt(tokens[2]);

                String elementForDivision = data.get(index);

                int sizeOfElementForDivision = elementForDivision.length();
                int partitionSize = sizeOfElementForDivision / partitions;

                ArrayList<String> newList = new ArrayList<>();

                int startIndex = 0;
                int endIndex = partitionSize;
                String concat = "";

                for (int i = 0; i < partitions - 1; i++) {
                    concat = elementForDivision.substring(startIndex, endIndex);
                    newList.add(concat);
                    startIndex += partitionSize;
                    endIndex += partitionSize;
                }

                concat = elementForDivision.substring(startIndex);
                newList.add(concat);

                data.remove(index);
                data.addAll(index, newList);
            }
        }
        System.out.println(data.toString().replaceAll("[\\[\\],]", ""));
    }

    private static void merge(ArrayList<String> data, int startIndex, int endIndex) {
        if (startIndex < 0) {
            startIndex = 0;
        }
        if (endIndex > data.size() - 1) {
            endIndex = data.size() - 1;
        }

        for (int i = startIndex; i < endIndex; i++) {
            String newElement = data.get(startIndex) + data.get(startIndex + 1);
            data.set(startIndex, newElement);
            data.remove(startIndex + 1);
        }
    }
}
