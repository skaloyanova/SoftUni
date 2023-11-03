package i_Lists;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class MergingLists {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> leftList = readIntList(sc);
        List<Integer> rightList = readIntList(sc);
        List<Integer> resultList = new ArrayList<>();

        int leftSize = leftList.size();
        int rightSize = rightList.size();
        int longerSize = Math.max(leftSize, rightSize);
        int shorterSize = Math.min(leftSize, rightSize);

        for (int i = 0; i < shorterSize; i++) {

            resultList.add(leftList.get(i));
            resultList.add(rightList.get(i));
        }

        if (leftSize > rightSize) {
            for (int i = shorterSize; i < longerSize; i++) {
                resultList.add(leftList.get(i));
            }
        } else {
            for (int i = shorterSize; i < longerSize; i++) {
                resultList.add(rightList.get(i));
            }
        }

        for (Integer integer : resultList) {
            System.out.print(integer + " ");
        }
    }

    public static List<Integer> readIntList(Scanner sc) {
        String input = sc.nextLine();
        String[] lineArr = input.split(" ");
        List<Integer> newList = new ArrayList<>();

        for (String str : lineArr) {
            int element = Integer.parseInt(str);
            newList.add(element);
        }
        return newList;
    }
}
