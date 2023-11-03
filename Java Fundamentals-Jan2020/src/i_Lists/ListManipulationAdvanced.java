package i_Lists;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class ListManipulationAdvanced {
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
                case "Contains":
                    containsNumber(numbersList, command[1]);
                    break;
                case "Print":
                    printEvenOdd(numbersList, command[1]);
                    break;
                case "Get":
                    printSum(numbersList);
                    break;
                case "Filter":
                    filterNumbers(numbersList, command[1], command[2]);
                    break;
            }
        }
    }

    private static void filterNumbers(List<Integer> inputList, String condition, String startEndNum) {
        int startEndNumber = Integer.parseInt(startEndNum);

        switch (condition) {
            case ">":
                for (Integer num : inputList) {
                    if (num > startEndNumber) {
                        System.out.print(num + " ");
                    }
                }
                break;
            case ">=":
                for (Integer num : inputList) {
                    if (num >= startEndNumber) {
                        System.out.print(num + " ");
                    }
                }
                break;
            case "<":
                for (Integer num : inputList) {
                    if (num < startEndNumber) {
                        System.out.print(num + " ");
                    }
                }
                break;
            case "<=":
                for (Integer num : inputList) {
                    if (num <= startEndNumber) {
                        System.out.print(num + " ");
                    }
                }
                break;
        }
        System.out.println();
    }

    private static void printSum(List<Integer> inputList) {
        int sum = 0;
        for (Integer num : inputList) {
            sum += num;
        }

        System.out.println(sum);
    }

    private static void printEvenOdd(List<Integer> inputList, String evenOdd) {
        List<Integer> evenNumbers = new ArrayList<>();
        List<Integer> oddNumbers = new ArrayList<>();

        for (Integer num : inputList) {
            if (num % 2 == 0) {
                evenNumbers.add(num);
            } else {
                oddNumbers.add(num);
            }
        }

        if (evenOdd.equals("even")) {
            printList(evenNumbers);
        } else if (evenOdd.equals("odd")) {
            printList(oddNumbers);
        }
    }

    private static void printList(List<Integer> intList) {
        for (Integer num : intList) {
            System.out.print(num + " ");
        }
        System.out.println();
    }

    private static void containsNumber(List<Integer> inputList, String s) {
        int number = Integer.parseInt(s);

        if (inputList.contains(number)) {
            System.out.println("Yes");
        } else {
            System.out.println("No such number");
        }
    }
}
