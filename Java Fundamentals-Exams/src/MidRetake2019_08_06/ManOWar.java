package MidRetake2019_08_06;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class ManOWar {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] statusPirateShip = sc.nextLine().split(">");     //ints
        String[] statusWarShip = sc.nextLine().split(">");     //ints
        int maxHealth = Integer.parseInt(sc.nextLine());

        List<Integer> pirateShip = Arrays.stream(statusPirateShip).map(Integer::parseInt).collect(Collectors.toList());
        List<Integer> warShip = Arrays.stream(statusWarShip).map(Integer::parseInt).collect(Collectors.toList());

        while (true) {
            String input = sc.nextLine();
            if ("Retire".equals(input)) {
                break;
            }

            String[] tokens = input.split("\\s+");

            switch (tokens[0]) {
                case "Fire": {
                    int index = Integer.parseInt(tokens[1]);
                    int damage = Integer.parseInt(tokens[2]);

                    if (notValidIndex(warShip, index)) {
                        break;
                    }

                    int oldSectionValue = warShip.get(index);
                    int newSectionValue = oldSectionValue - damage;

                    if (newSectionValue > 0) {
                        warShip.set(index, newSectionValue);
                    } else {
                        System.out.println("You won! The enemy ship has sunken.");
                        return;
                    }
                    break;
                }
                case "Defend": {
                    int startIndex = Integer.parseInt(tokens[1]);
                    int endIndex = Integer.parseInt(tokens[2]);
                    int damage = Integer.parseInt(tokens[3]);

                    if (notValidIndex(pirateShip, startIndex) || notValidIndex(pirateShip, endIndex)) {
                        break;
                    }

                    for (int i = startIndex; i <= endIndex; i++) {
                        int oldSectionValue = pirateShip.get(i);
                        int newSectionValue = oldSectionValue - damage;

                        if (newSectionValue > 0) {
                            pirateShip.set(i, newSectionValue);
                        } else {
                            System.out.println("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }
                    break;
                }
                case "Repair": {
                    int index = Integer.parseInt(tokens[1]);
                    int health = Integer.parseInt(tokens[2]);

                    if (notValidIndex(pirateShip, index)) {
                        break;
                    }

                    int newSectionHealth = pirateShip.get(index) + health;
                    if (newSectionHealth > maxHealth) {
                        newSectionHealth = maxHealth;
                    }

                    pirateShip.set(index, newSectionHealth);
                    break;
                }
                case "Status":
                    int count = 0;
                    for (Integer s : pirateShip) {
                        if (s < 0.2 * maxHealth) {
                            count++;
                        }
                    }

                    System.out.println(count + " sections need repair.");
                    break;
            }
        }

        System.out.println("Pirate ship status: " + sumOfSections(pirateShip));
        System.out.println("Warship status: " + sumOfSections(warShip));

    }

    private static boolean notValidIndex(List<Integer> list, int index) {
        return index < 0 || index >= list.size();
    }

    private static int sumOfSections(List<Integer> list) {
        int sum = 0;
        for (Integer integer : list) {
            sum += integer;
        }
        return sum;
    }
}
