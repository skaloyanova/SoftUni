package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class AppendArrays {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\|+");
        ArrayList<String> result = new ArrayList<>();

        for (int i = input.length - 1; i >= 0; i--) {
            String[] current = input[i].trim().split("\\s+");
            result.addAll(Arrays.asList(current));
            result.remove("");
        }

        System.out.println(String.join(" ", result));
    }
}
