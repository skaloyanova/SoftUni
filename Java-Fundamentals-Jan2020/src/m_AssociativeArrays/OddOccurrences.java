package m_AssociativeArrays;

import java.util.*;

public class OddOccurrences {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] words = sc.nextLine().toLowerCase().split(" ");
        Map<String, Integer> counts = new LinkedHashMap<>();

        for (String word : words) {
            counts.putIfAbsent(word, 0);
            counts.put(word, counts.get(word) + 1);
        }

        List<String> odds = new ArrayList<>();
        for (Map.Entry<String, Integer> entry : counts.entrySet()) {
            if (entry.getValue() % 2 != 0) {
            odds.add(entry.getKey());
            }
        }

        System.out.println(String.join(", ", odds));
    }
}
