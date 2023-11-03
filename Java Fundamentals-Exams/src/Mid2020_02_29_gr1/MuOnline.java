package Mid2020_02_29_gr1;

import java.util.Scanner;

public class MuOnline {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] dungeons = sc.nextLine().split("\\|");

        int maxHealth = 100;
        int bitcoins = 0;
        int health = maxHealth;

        for (int i = 0; i < dungeons.length; i++) {
            String dungeon = dungeons[i];
            String[] currentDungeon = dungeon.split(" ");
            String command = currentDungeon[0];
            int value = Integer.parseInt(currentDungeon[1]);

            switch (command) {
                case "potion":
                    if (health + value > maxHealth) {
                        value = maxHealth - health;
                    }
                    health += value;
                    System.out.printf("You healed for %d hp.%n", value);
                    System.out.printf("Current health: %d hp.%n", health);
                    break;
                case "chest":
                    bitcoins += value;
                    System.out.printf("You found %d bitcoins.%n", value);
                    break;
                default:
                    health -= value;
                    if (health > 0) {
                        System.out.println(String.format("You slayed %s.", command));
                    } else {
                        System.out.println(String.format("You died! Killed by %s.", command));
                        System.out.println("Best room: " + (i + 1));
                        return;
                    }
                    break;
            }

        }
        //output
        System.out.println("You've made it!");
        System.out.println("Bitcoins: " + bitcoins);
        System.out.println("Health: " + health);
    }
}
