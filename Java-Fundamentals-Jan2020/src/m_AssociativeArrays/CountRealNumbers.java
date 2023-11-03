package m_AssociativeArrays;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class CountRealNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] input = sc.nextLine().split("\\s+");

        Map<String, Integer> count = new TreeMap<>();

        for (String s : input) {
            count.putIfAbsent(s, 0);
            count.put(s, count.get(s) + 1);
        }

        for (Map.Entry<String, Integer> entry : count.entrySet()) {
            System.out.println(String.format("%s -> %s", entry.getKey(), entry.getValue()));
        }
    }

}
