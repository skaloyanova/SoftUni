package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class xMessaging {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] numArr = sc.nextLine().split("\\s+");
        String[] textArr = sc.nextLine().split("");


        ArrayList<Integer> numbers = new ArrayList<>();
        ArrayList<String> text = new ArrayList<>(Arrays.asList(textArr));

        for (String num : numArr) {
            numbers.add(Integer.parseInt(num));
        }

        for (int i = 0; i < numbers.size(); i++) {
            int index = sumDigitsOfNumber(numbers.get(i));
            index = index % text.size();
            String letter = text.remove(index);
            System.out.print(letter);
        }

    }

    public static int sumDigitsOfNumber(int num) {
        int sum = 0;
        while (num > 0) {
            sum += num % 10;
            num = num /10;
        }
        return sum;
    }
}
