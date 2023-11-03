package z_Exam_20191217_Retake;

import java.util.*;
import java.util.stream.Collectors;

public class SantaPresentFactory {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        //stack - push, pop, peek
        ArrayDeque<Integer> materials = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt).filter(x -> x != 0).forEach(materials::push);

        //queue - offer, poll, peek
        ArrayDeque<Integer> magic = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt).filter(x -> x != 0).forEach(magic::offer);

        Map<String, Integer> presents = new TreeMap<>();

        while (materials.size() > 0 && magic.size() > 0) {
            int material = materials.pop();
            int magicLevel = magic.poll();

            int mix = material * magicLevel;
            String present = getPresent(mix);

            if (present != null) {
                presents.putIfAbsent(present, 0);
                presents.put(present, presents.get(present) + 1);
                continue;
            }

            material = mix < 0 ? material + magicLevel : material + 15;
            if (material != 0) {
                materials.push(material);
            }
        }

        // print
        boolean successOption1 = presents.containsKey("Doll") && presents.containsKey("Wooden train");
        boolean successOption2 = presents.containsKey("Teddy bear") && presents.containsKey("Bicycle");

        if (successOption1 || successOption2) {
            System.out.println("The presents are crafted! Merry Christmas!");
        } else {
            System.out.println("No presents this Christmas!");
        }

        if (materials.size() > 0) {
            System.out.println("Materials left: "
                    + materials.stream().map(String::valueOf).collect(Collectors.joining(", ")));
        }

        if (magic.size() > 0) {
            System.out.println("Magic left: "
                    + magic.stream().map(String::valueOf).collect(Collectors.joining(", ")));
        }

        presents.forEach((k,v) -> System.out.println(k + ": " + v));
    }

    private static String getPresent(int mix) {
        switch (mix) {
            case 150: return "Doll";
            case 250: return "Wooden train";
            case 300: return "Teddy bear";
            case 400: return "Bicycle";
            default: return null;
        }
    }
}
