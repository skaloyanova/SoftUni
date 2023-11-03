package q_RegularExpressions_Lab_Exercise;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class xRageQuit {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine().toUpperCase();

        String[] text = input.toUpperCase().split("\\d+");
        List<Integer> num = new ArrayList<>();

        Matcher numberMatch = Pattern.compile("\\d+").matcher(input);
        while (numberMatch.find()) {
            num.add(Integer.parseInt(numberMatch.group()));
        }

        StringBuilder message = new StringBuilder();

        for (int i = 0; i < text.length; i++) {
            int count = num.get(i);
            for (int j = 0; j < count; j++) {
                message.append(text[i]);
            }
        }

        Map<Character,Integer> countSym = new HashMap<>();
        String symbols = String.join("", text);
        for (int i = 0; i < message.length(); i++) {
            countSym.put(message.charAt(i), 0);
        }

        System.out.println("Unique symbols used: " + countSym.size());
        System.out.println(message);
    }
}
