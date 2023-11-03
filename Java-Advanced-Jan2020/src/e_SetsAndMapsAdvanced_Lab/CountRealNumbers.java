package e_SetsAndMapsAdvanced_Lab;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class CountRealNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<Double, Integer> count = new LinkedHashMap<>();

        String[] tokens = sc.nextLine().split("\\s+");

        for (String token : tokens) {
            double number = Double.parseDouble(token);
            count.putIfAbsent(number, 0);
            count.put(number, count.get(number) + 1);
        }

        count.forEach((k,v) -> System.out.println(String.format("%.1f -> %d", k, v)));
    }
}
