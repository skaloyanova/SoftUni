package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class xMixedUpLists {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        ArrayList<Integer> first = readIntList(sc);
        ArrayList<Integer> second = readIntList(sc);

        ArrayList<Integer> combined = new ArrayList<>();

        int smallestSize = Math.min(first.size(), second.size());

        for (int i = 0; i < smallestSize; i++) {
            int elementFirst = first.remove(0);
            int elementSecond = second.remove(second.size() - 1);

            combined.add(elementFirst);
            combined.add(elementSecond);
        }
        int num1;
        int num2;
        if (first.size() > 0) {
            num1 = first.get(0);
            num2 = first.get(1);
        } else {
            num1 = second.get(0);
            num2 = second.get(1);
        }

        int min = Math.min(num1, num2);
        int max = Math.max(num1, num2);

        combined.removeIf(number -> (number <= min || number >= max));
        Collections.sort(combined);

        System.out.println(combined.toString().replaceAll("[\\[\\],]", ""));
    }

    private static ArrayList<Integer> readIntList(Scanner sc) {
        String[] input = sc.nextLine().split("\\s+");
        ArrayList<Integer> intArrayList = new ArrayList<>();

        for (String element : input) {
            intArrayList.add(Integer.parseInt(element));
        }
        return intArrayList;
    }
}
