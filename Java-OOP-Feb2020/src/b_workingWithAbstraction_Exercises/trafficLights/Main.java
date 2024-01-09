package b_workingWithAbstraction_Exercises.trafficLights;

import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        TrafficLight[] trafficLights = Arrays.stream(sc.nextLine().split("\\s+"))
                .map(e -> TrafficLight.valueOf(e))
                .toArray(TrafficLight[]::new);

        int n = Integer.parseInt(sc.nextLine());

        // red(0) -> green(1) -> yellow(2) -> red

        for (int i = 0; i < n; i++) {

            for (int j = 0; j < trafficLights.length; j++) {
                int nextOrdinal = trafficLights[j].ordinal() + 1;
                trafficLights[j] = getNextState(nextOrdinal);
            }
            System.out.println(Arrays.toString(trafficLights).replaceAll("[\\[\\],]", ""));
        }
    }

    private static TrafficLight getNextState(int ordinal) {
        ordinal = ordinal % 3;
        TrafficLight[] trafficLights = TrafficLight.values();
        return trafficLights[ordinal];
    }
}
