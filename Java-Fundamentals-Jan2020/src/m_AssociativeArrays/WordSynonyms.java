package m_AssociativeArrays;

import java.util.*;

public class WordSynonyms {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        Map<String, List<String>> synonyms = new LinkedHashMap<>();

        for (int i = 0; i < n; i++) {
            String word = sc.nextLine();
            String syn = sc.nextLine();

            synonyms.putIfAbsent(word, new ArrayList<>());
            synonyms.get(word).add(syn);

        }

        for (Map.Entry<String, List<String>> entry : synonyms.entrySet()) {
            System.out.println(String.format("%s - %s", entry.getKey(), String.join(", ", entry.getValue())));
        }
    }
}
