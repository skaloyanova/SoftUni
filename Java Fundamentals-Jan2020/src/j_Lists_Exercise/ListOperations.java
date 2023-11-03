package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class ListOperations {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] inputArr = sc.nextLine().split("\\s+");

        ArrayList<String> numberList = new ArrayList<>(Arrays.asList(inputArr));

        String input = sc.nextLine();

        while (!"End".equals(input)) {
            String[] tokens = input.split("\\s+");

            switch (tokens[0]) {
                case "Add":
                    numberList.add(tokens[1]);
                    break;
                case "Insert":
                    int index = Integer.parseInt(tokens[2]);
                    if (index >= 0 && index <numberList.size()) {
                        numberList.add(index, tokens[1]);
                    } else {
                        System.out.println("Invalid index");
                    }
                    break;
                case "Remove":
                    int indexRem = Integer.parseInt(tokens[1]);
                    if (indexRem >= 0 && indexRem <numberList.size()) {
                        numberList.remove(indexRem);
                    } else {
                        System.out.println("Invalid index");
                    }
                    break;
                case "Shift":
                    int count = Integer.parseInt(tokens[2]);
                    switch (tokens[1]) {
                        case "left":
                            for (int i = 0; i < count; i++) {
                                numberList.add(numberList.get(0));
                                numberList.remove(0);
                            }
                            break;
                        case "right":
                            for (int i = 0; i < count; i++) {
                                numberList.add(0, numberList.get(numberList.size() - 1));
                                numberList.remove(numberList.size() - 1);
                            }
                            break;
                    }
                    break;
            }

            input = sc.nextLine();
        }
        System.out.println(String.join(" ", numberList));
    }
}
