package f_SetsAndMapsAdvanced_Exercises;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class MinerTask {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String,Integer> items = new LinkedHashMap<>();
        String resource = sc.nextLine();
        while (!"stop".equals(resource)) {
            int quantity = Integer.parseInt(sc.nextLine());
            items.putIfAbsent(resource, 0);
            items.put(resource, items.get(resource) + quantity);

            resource = sc.nextLine();
        }

        items.forEach((k,v) -> System.out.println(k + " -> " + v));
    }
}
