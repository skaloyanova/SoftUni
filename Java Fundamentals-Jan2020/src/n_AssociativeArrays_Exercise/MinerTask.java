package n_AssociativeArrays_Exercise;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class MinerTask {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> resourceCnt = new LinkedHashMap<>();

        String input = sc.nextLine();

        while (!"stop".equals(input)) {
            String resource = input;
            resourceCnt.putIfAbsent(resource, 0);

            int quantity = Integer.parseInt(sc.nextLine());
            resourceCnt.put(resource, resourceCnt.get(resource) + quantity);

            input = sc.nextLine();
        }

        for (Map.Entry<String, Integer> entry : resourceCnt.entrySet()) {
            System.out.println(String.format("%s -> %d", entry.getKey(), entry.getValue()));
        }
    }

}
