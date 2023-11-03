package z_Exam_20180103_archived;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class SwanStation {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> theNumbers = Arrays.stream(sc.nextLine().split("\\s"))
                .map(Integer::parseInt).collect(Collectors.toList());

        List<Integer> numToEnter = Arrays.stream(sc.nextLine().split("\\s"))
                .map(Integer::parseInt).collect(Collectors.toList());

        List<Integer> result = new ArrayList<>();

        while (result.size() < 6) {
            int firstToEnter =numToEnter.remove(0);

            if (firstToEnter % theNumbers.get(0) == 0) {
                result.add(firstToEnter);
                theNumbers.remove(0);
            } else {
                numToEnter.add(firstToEnter + 1);
            }
        }
        System.out.println(result.toString().replaceAll("[\\[\\]]", ""));
    }
}
