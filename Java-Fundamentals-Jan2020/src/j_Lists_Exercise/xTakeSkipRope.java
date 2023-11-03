package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Scanner;

public class xTakeSkipRope {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char[] input = sc.nextLine().toCharArray();

        ArrayList<Character> textList = new ArrayList<>();
        ArrayList<Integer> numberList = new ArrayList<>();

        for (char c : input) {
            if (Character.isDigit(c)) {
                numberList.add(Integer.parseInt(String.valueOf(c)));
            } else {
                textList.add(c);
            }
        }

        ArrayList<Integer> takeList = new ArrayList<>();
        ArrayList<Integer> skipList = new ArrayList<>();

        for (int i = 0; i < numberList.size(); i++) {
            if (i % 2 == 0) {
                takeList.add(numberList.get(i));
            } else {
                skipList.add(numberList.get(i));
            }
        }

        String result = "";
        int startIndexTake = 0;
        for (int i = 0; i < takeList.size(); i++) {
            int countTaken = takeList.get(i);
            int textIndex = startIndexTake;

            for (int j = 0; j < countTaken; j++) {
                if (textIndex >= textList.size()) {
                    break;
                }
                result += textList.get(textIndex++);
            }

            startIndexTake = startIndexTake + takeList.get(i) + skipList.get(i);
        }
        System.out.println(result);
    }
}
