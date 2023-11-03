package l_Generics_Exercises;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        /*---------------------------------------------------------------*/
        // 03. Generic Swap Method String
        /*---------------------------------------------------------------*/
//        List<Box<String>> listStr = createListOfStringBoxes(sc);
//
//        swap(listStr, sc.nextInt(), sc.nextInt());
//        sc.nextLine();
//
//        printList(listStr);

        /*---------------------------------------------------------------*/
        // 04. Generic Swap Method Integer
        /*---------------------------------------------------------------*/
//        List<Box<Integer>> listInt = createListOfIntegerBoxes(sc);
//
//        swap(listInt, sc.nextInt(), sc.nextInt());
//        sc.nextLine();
//
//        printList(listInt);

        /*---------------------------------------------------------------*/
        // 05. Generic Count Method String
        /*---------------------------------------------------------------*/
//        List<Box<String>> listStr = createListOfStringBoxes(sc);
//
//        Box<String> element = new Box<>(sc.nextLine());
//        System.out.println(countGraterElements(listStr, element));

        /*---------------------------------------------------------------*/
        // 06. Generic Count Method Double
        /*---------------------------------------------------------------*/
//        List<Box<Double>> listDbl = createListOfDoubleBoxes(sc);
//
//        Box<Double> element = new Box<>(Double.parseDouble(sc.nextLine()));
//        System.out.println(countGraterElements(listDbl, element));

        /*---------------------------------------------------------------*/
        // 10. Tuple
        /*---------------------------------------------------------------*/
//        String[] tokens = sc.nextLine().split("\\s+");
//        Tuple<String, String> tup1 = new Tuple<>(tokens[0] + " " + tokens[1], tokens[2]);
//
//        tokens = sc.nextLine().split("\\s+");
//        Tuple<String, Integer> tup2 = new Tuple<>(tokens[0], Integer.parseInt(tokens[1]));
//
//        tokens = sc.nextLine().split("\\s+");
//        Tuple<String, Double> tup3 = new Tuple<>(tokens[0], Double.parseDouble(tokens[1]));
//
//        System.out.println(tup1);
//        System.out.println(tup2);
//        System.out.println(tup3);

        /*---------------------------------------------------------------*/
        // 11. Threeuple
        /*---------------------------------------------------------------*/

        String[] tokens = sc.nextLine().split("\\s+");
        Threeuple<String, String, String> three1 = new Threeuple<>(tokens[0] + " " + tokens[1], tokens[2], tokens[3]);

        tokens = sc.nextLine().split("\\s+");
        boolean t3 = tokens[2].equals("drunk");
        Threeuple<String, Integer, Boolean> three2 = new Threeuple<>(tokens[0], Integer.parseInt(tokens[1]), t3);

        tokens = sc.nextLine().split("\\s+");
        Threeuple<String, Double, String> three3 = new Threeuple<>(tokens[0], Double.parseDouble(tokens[1]), tokens[2]);

        StringBuilder sb = new StringBuilder();
        sb.append(three1).append(System.lineSeparator());
        sb.append(three2).append(System.lineSeparator());
        sb.append(three3).append(System.lineSeparator());
        System.out.println(sb);
    }


//    private static List<Box<String>> createListOfStringBoxes(Scanner sc) {
//        List<Box<String>> list = new ArrayList<>();
//        int size = Integer.parseInt(sc.nextLine());
//
//        for (int i = 0; i < size; i++) {
//            list.add(new Box<>(sc.nextLine()));
//        }
//        return list;
//    }
//
//    private static List<Box<Integer>> createListOfIntegerBoxes(Scanner sc) {
//        List<Box<Integer>> list = new ArrayList<>();
//        int size = Integer.parseInt(sc.nextLine());
//
//        for (int i = 0; i < size; i++) {
//            list.add(new Box<>(Integer.parseInt(sc.nextLine())));
//        }
//        return list;
//    }
//
//    private static List<Box<Double>> createListOfDoubleBoxes(Scanner sc) {
//        List<Box<Double>> list = new ArrayList<>();
//        int size = Integer.parseInt(sc.nextLine());
//
//        for (int i = 0; i < size; i++) {
//            list.add(new Box<>(Double.parseDouble(sc.nextLine())));
//        }
//        return list;
//    }
//
//    private static <T> void printList(List<T> list) {
//        for (T box : list) {
//            System.out.println(box);
//        }
//    }
//
//    private static <T> void swap(List<T> list, int index1, int index2) {
//        if (index1 < 0 || index1 >= list.size() || index2 < 0 || index2 >= list.size() || list.size() < 2) {
//            return;
//        }
//        T tempIdx1 = list.set(index1, list.get(index2));
//        list.set(index2, tempIdx1);
//    }
//
//    private static <T extends Comparable<T>> int countGraterElements(List<Box<T>> list, Box<T> element) {
//        int count = 0;
//        for (Box<T> box : list) {
//            if (box.compareTo(element) > 0) {
//                count++;
//            }
//        }
//        return count;
//    }
}
