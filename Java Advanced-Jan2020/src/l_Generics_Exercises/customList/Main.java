package l_Generics_Exercises.customList;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        CustomList<String> list = new CustomList<>();

        String input = sc.nextLine();
        while (!"END".equals(input)) {
            String[] tokens = input.split("\\s+");

            switch (tokens[0]) {
                case "Add":
                    list.add(tokens[1]);
                    break;
                case "Remove":
                    list.remove(Integer.parseInt(tokens[1]));
                    break;
                case "Contains":
                    System.out.println(list.contains(tokens[1]));
                    break;
                case "Swap":
                    list.swap(Integer.parseInt(tokens[1]), Integer.parseInt(tokens[2]));
                    break;
                case "Greater":
                    System.out.println(list.countGreaterThan(tokens[1]));
                    break;
                case "Max":
                    System.out.println(list.getMax());
                    break;
                case "Min":
                    System.out.println(list.getMin());
                    break;
                case "Print":
                    list.print();
                    break;
                case "Sort":
                    list.sort();
                    break;
            }

            input = sc.nextLine();
        }

//        CustomList<Integer> list = new CustomList<>();

//        list.add(2);
//        list.add(10);
//        list.add(19);
//
//        System.out.println(list);
//        System.out.println("get element at index 2: " + list.get(2));
//
//        System.out.println("remove element at index 1: " + list.remove(1));
//        System.out.println(list);
//
//        System.out.println("list contains 2: " + list.contains(2));
//        System.out.println("list contains 3: " + list.contains(3));
//
//        System.out.println("swap elements at indexes 0 and 1");
//        list.swap(0, 1);
//        System.out.println(list);
//
//        System.out.println("count greater than 1: " + list.countGreaterThan(1));
//        System.out.println("count greater than 5: " + list.countGreaterThan(5));
//        System.out.println("count greater than 20: " + list.countGreaterThan(20));
//
//        list.add(7);
//        list.add(23);
//
//        System.out.println(list);
//        System.out.println("min: " + list.getMin());
//        System.out.println("max: " + list.getMax());

    }
}
