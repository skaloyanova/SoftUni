package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Consumer;

public class KnightsOfHonor {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Consumer<String> addSir = x -> System.out.println("Sir " + x);

        Arrays.stream(sc.nextLine().split("\\s+"))
                .forEach(addSir);
    }
}
