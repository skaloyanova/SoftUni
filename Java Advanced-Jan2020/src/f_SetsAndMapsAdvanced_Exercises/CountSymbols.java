package f_SetsAndMapsAdvanced_Exercises;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class CountSymbols {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char[] text = sc.nextLine().toCharArray();

        Map<Character,Integer> count = new TreeMap<>();

        for (char c : text) {
            count.putIfAbsent(c, 0);
            count.put(c, count.get(c) + 1);
        }

        count.forEach((k,v) -> System.out.println(String.format("%c: %d time/s",k, v)));
    }
}
