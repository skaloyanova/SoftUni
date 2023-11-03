package i_Lists;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class GaussTrick {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        List<Integer> input = Arrays.stream(text.split(" ")).map(Integer::parseInt).collect(Collectors.toList());

        int iterations = input.size() / 2;

        for (int i = 0; i < iterations; i++) {
            int sum = input.get(i) + input.get(input.size() - 1);
            input.set(i, sum);
            input.remove(input.size() - 1);
        }

        for (int number : input) {
            System.out.print(number + " ");
        }
    }
}
