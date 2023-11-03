package n_IteratorsAndComparators_Exercises.froggy;

import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] lakeNumbers = Arrays.stream(sc.nextLine().split(", ")).mapToInt(Integer::parseInt).toArray();
        sc.nextLine();  //to catch the "END" command

        Lake lake = new Lake(lakeNumbers);

        StringBuilder sb = new StringBuilder();
        for (Integer integer : lake) {
            sb.append(integer).append(", ");
        }

        int lastComma = sb.toString().lastIndexOf(",");
        System.out.println(sb.substring(0, lastComma));

    }
}
