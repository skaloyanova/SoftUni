package b_StacksAndQueues_Exercises;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;

public class PoisonousPlants {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int plantsCnt = Integer.parseInt(sc.nextLine());
        int[] plants = Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt).toArray();

        int[] days = new int[plantsCnt];

        ArrayDeque<Integer> leftPlantIndex = new ArrayDeque<>();
        leftPlantIndex.push(0);

        for (int right = 1; right < plants.length; right++) {
           int day = 0;

           while (!leftPlantIndex.isEmpty() && plants[leftPlantIndex.peek()] >= plants[right]) {    //plant is ALIVE
               day = Math.max(day, days[leftPlantIndex.pop()]);
           }

           if (!leftPlantIndex.isEmpty()) { //plant is DEAD, so increasing days
               days[right] = day + 1;
           }

           leftPlantIndex.push(right);
        }
        System.out.println(Arrays.stream(days).max().getAsInt());

        //VARIANT 1
//        List<Integer> pesticideList = Arrays.stream(sc.nextLine().split("\\s+"))
//                .map(Integer::parseInt).collect(Collectors.toList());
//
//        int days = 0;
//
//        while(true) {
//            int removedPlants = 0;
//            for (int i = pesticideList.size() - 1; i > 0; i--) {
//                if (pesticideList.get(i) > pesticideList.get(i - 1)) {
//                    pesticideList.remove(i);
//                    removedPlants++;
//                }
//            }
//            if (removedPlants == 0) {
//                break;
//            }
//            days++;
//        }
//        System.out.println(days);
    }
}
