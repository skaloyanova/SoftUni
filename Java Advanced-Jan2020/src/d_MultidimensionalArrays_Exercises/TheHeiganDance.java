package d_MultidimensionalArrays_Exercises;

import java.util.Scanner;

public class TheHeiganDance {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int playerHP = 18_500;
        double bossHP = 3_000_000;

        double damage = Double.parseDouble(sc.nextLine());

        // field 15 x 15, i.e. indices 0-14 / 0-14
        int rowPlayer = 7;
        int colPlayer = 7;
        String currentSpell = "";
        boolean isActiveCloud = false;

        while (true) {
            // HIT the boss
            bossHP -= damage;

            // Check if there is active Plague spell
            if (isActiveCloud) {
                playerHP -= 3500;
                isActiveCloud = false;
            }

            if (bossHP <= 0 || playerHP <= 0) {
                break;
            }

            // read spell and hit target
            String[] tokens = sc.nextLine().split("\\s+");
            currentSpell = tokens[0];
            int rowHit = Integer.parseInt(tokens[1]);
            int colHit = Integer.parseInt(tokens[2]);

            // Verifying input - spell can hit at -1 and at 15, this way at least 1 field space will be hit
            // it input is invalid, continue to next turn
            if (rowHit < -1 || rowHit > 15 || colHit < -1 || colHit > 15) {
                continue;
            }

            //check if Player is within Damaged area and if "not", continue to next turn
            if (!isPlayerInDmgArea(rowPlayer, colPlayer, rowHit, colHit)) {
                continue;
            }

            // continue further if both Player and boss are still alive and Player is within damaged area

            boolean playerIsHit = false;

            // check if casted spell Hits the Player

                // player can move UP
            if (rowPlayer == rowHit - 1 && isWithinField(rowPlayer - 1)) {
                rowPlayer--;

                // player can move RIGHT
            } else if (colPlayer == colHit + 1 && (rowPlayer == rowHit || rowPlayer == rowHit + 1)
                    && isWithinField(colPlayer + 1)) {
                colPlayer++;

                // player can move DOWN
            } else if (rowPlayer == rowHit + 1 && (colPlayer == colHit - 1 || colPlayer == colHit)
                    && isWithinField(rowPlayer + 1)) {
                rowPlayer++;

                // player can move LEFT
            } else if (rowPlayer == rowHit && colPlayer == colHit - 1 && isWithinField(colPlayer - 1)) {
                colPlayer--;

                // player CANNOT move
            } else {
                playerIsHit = true;
            }

            if (playerIsHit) {
                switch (currentSpell) {
                    case "Cloud":
                        playerHP -= 3500;
                        isActiveCloud = true;
                        break;
                    case "Eruption":
                        playerHP -= 6000;
                        break;
                }
                if (playerHP <= 0) {
                    break;
                }
            }
        }

        //output
        if ("Cloud".equalsIgnoreCase(currentSpell)) {
            currentSpell = "Plague " + currentSpell;
        }

        String bossState = (bossHP <= 0) ? "Heigan: Defeated!" : String.format("Heigan: %.2f", bossHP);
        String playerState = (playerHP <= 0) ? String.format("Player: Killed by %s", currentSpell) :
                String.format("Player: %d", playerHP);
        String playerCoordinates = String.format("Final position: %d, %d", rowPlayer, colPlayer);

        System.out.println(bossState);
        System.out.println(playerState);
        System.out.println(playerCoordinates);
    }

    private static boolean isPlayerInDmgArea(int rowPlayer, int colPlayer, int rowHit, int colHit) {
        return rowPlayer >= rowHit - 1 && rowPlayer <= rowHit + 1 &&
                colPlayer >= colHit - 1 && colPlayer <= colHit + 1;
    }

    private static boolean isWithinField(int i) {
        return i >= 0 && i < 15;
    }
}
