package l_Generics_Exercises.ListUtils;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Main {
    public static void main(String[] args) {

        List<Integer> ints = new ArrayList<>();
        Collections.addAll(ints, 1, 2, 10, 3, 15, 7);
        System.out.println(ints);

        Integer minInt = ListUtils.getMin(ints);
        Integer maxInt = ListUtils.getMax(ints);
        System.out.println("min: " + minInt);
        System.out.println("max: " + maxInt);

        List<String> strings = new ArrayList<>();
        Collections.addAll(strings, "a", "f", "d", "k");
        System.out.println(strings);

        String minStr = ListUtils.getMin(strings);
        String maxStr = ListUtils.getMax(strings);
        System.out.println("min: " + minStr);
        System.out.println("max: " + maxStr);

    }
}
