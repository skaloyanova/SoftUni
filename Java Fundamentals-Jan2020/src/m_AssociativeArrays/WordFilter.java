package m_AssociativeArrays;

import java.util.Arrays;
import java.util.Scanner;

public class WordFilter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] words = sc.nextLine().split(" ");

        Arrays.stream(words)
                .filter(w -> w.length() % 2 == 0)
                .forEach(System.out::println);
    }
}
