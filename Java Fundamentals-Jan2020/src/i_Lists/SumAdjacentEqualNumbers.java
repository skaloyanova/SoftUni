package i_Lists;

import java.text.DecimalFormat;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class SumAdjacentEqualNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<Double> input = Arrays.stream(sc.nextLine().split(" "))
                .map(Double::parseDouble).collect(Collectors.toList());

        //8 2 2 4 8 16  8 4 4 8 16  8 8 8 16  16 8 16

        for (int i = 0; i < input.size() - 1; i++) {
            if (input.get(i).equals(input.get(i + 1))) {
                double sum = input.get(i) * 2;
                input.set(i, sum);
                input.remove(i + 1);
                i = -1;
            }
        }

        printList(input);
    }

    private static void printList(List<Double> input) {
        for (int i = 0; i < input.size(); i++) {
            String current = new DecimalFormat("#.##").format(input.get(i));
            System.out.print(current + " ");
        }
    }
}
