package n_AssociativeArrays_Exercise;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class CountCharsInString {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        char[] input = sc.nextLine().toCharArray();

        Map<Character, Integer> counts = new LinkedHashMap<>();

        for (Character c : input) {
            if (c == ' ') {
                continue;
            }
            counts.putIfAbsent(c, 0);
            counts.put(c, counts.get(c) + 1);
        }

        for (Map.Entry<Character, Integer> entry : counts.entrySet()) {
            System.out.printf("%c -> %d%n", entry.getKey(), entry.getValue());
        }
        //counts.forEach((key, value) -> System.out.printf("%c -> %d%n", key, value));
    }
}
