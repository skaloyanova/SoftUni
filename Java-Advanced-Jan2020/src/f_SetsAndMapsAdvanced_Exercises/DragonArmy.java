package f_SetsAndMapsAdvanced_Exercises;

import java.util.*;

public class DragonArmy {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String,Map<String, int[]>> dragons = new LinkedHashMap<>();
        //<type, <name, [dmg, hp, arm]>>

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String type = tokens[0];
            String name = tokens[1];
            int damage = "null".equals(tokens[2]) ? 45 : Integer.parseInt(tokens[2]);
            int health = "null".equals(tokens[3]) ? 250 : Integer.parseInt(tokens[3]);
            int armor = "null".equals(tokens[4]) ? 10 : Integer.parseInt(tokens[4]);

            dragons.putIfAbsent(type, new TreeMap<>());
            dragons.get(type).putIfAbsent(name,new int[3]);
            dragons.get(type).get(name)[0] = damage;
            dragons.get(type).get(name)[1] = health;
            dragons.get(type).get(name)[2] = armor;
        }
        dragons.forEach((k,v) -> {
            double[] avg = calculateAverages(v);
            System.out.println(String.format("%s::(%.2f/%.2f/%.2f)", k, avg[0], avg[1], avg[2]));
            v.forEach((d, s) -> System.out.println(String.format("-%s -> damage: %d, health: %d, armor: %d",
                    d, s[0], s[1], s[2])));
        });
    }

    private static double[] calculateAverages(Map<String,int[]> stats) {
        double[] avg = new double[3];
        int sumDmg = 0;
        int sumHP = 0;
        int sumArm = 0;

        for (Map.Entry<String, int[]> stringEntry : stats.entrySet()) {
            sumDmg += stringEntry.getValue()[0];
            sumHP += stringEntry.getValue()[1];
            sumArm += stringEntry.getValue()[2];
        }
        avg[0] = sumDmg * 1.0 / stats.size();
        avg[1] = sumHP * 1.0 / stats.size();
        avg[2] = sumArm * 1.0 / stats.size();

        return avg;
    }
}
