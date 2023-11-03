package i_Lists;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class RemoveNegativesAndReverse {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> input = Arrays.stream(sc.nextLine().split(" "))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        for (int i = 0; i < input.size(); i++) {
            if (input.get(i) < 0) {
                input.remove(i);
                i--;
            }
        }

        if (input.size() == 0) {
            System.out.println("empty");
        } else {
            Collections.reverse(input);
            System.out.println(input.toString().replaceAll("[\\[\\],]", ""));
        }
    }
}
