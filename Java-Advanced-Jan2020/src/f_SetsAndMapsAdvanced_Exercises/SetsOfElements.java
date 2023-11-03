package f_SetsAndMapsAdvanced_Exercises;

import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class SetsOfElements {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int first = sc.nextInt();
        int second = sc.nextInt();
        sc.nextLine();

        Set<String> firstSet = new LinkedHashSet<>();
        Set<String> secondSet = new LinkedHashSet<>();
        Set<String> resultSet = new LinkedHashSet<>();

        for (int i = 0; i < first; i++) {
            firstSet.add(sc.nextLine());
        }

        for (int i = 0; i < second; i++) {
            secondSet.add(sc.nextLine());
        }

        for (String s : firstSet) {
            if (secondSet.contains(s)) {
                resultSet.add(s);
            }
        }

        for (String s : resultSet) {
            System.out.print(s + " ");
        }
    }
}
