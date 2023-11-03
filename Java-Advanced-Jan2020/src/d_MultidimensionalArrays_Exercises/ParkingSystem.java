package d_MultidimensionalArrays_Exercises;

import java.util.Scanner;

public class ParkingSystem {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();

        // first column is always free and all other cells are z_Exam_20200628.parking spots
        byte[][] parking = new byte[rows][cols];

        String input = sc.nextLine();
        while (!"stop".equals(input)) {
            String[] tokens = input.split("\\s+");
            int entryRow = Integer.parseInt(tokens[0]);
            int rowSpot = Integer.parseInt(tokens[1]);
            int colSpot = Integer.parseInt(tokens[2]);

            int colSpotFree = searchForBestSpot(parking, rowSpot, colSpot); //returns 0, if there are no free spots

            if (colSpotFree == 0) {
                System.out.println(String.format("Row %d full", rowSpot));
            } else {
                parking[rowSpot][colSpotFree] = 1;  //mark spot as busy

                int moves = Math.abs(entryRow - rowSpot) + colSpotFree + 1;
                System.out.println(moves);
            }

            input = sc.nextLine();
        }
    }

    private static int searchForBestSpot(byte[][] parking, int rowSpot, int colSpot) {
        int diffLeft = Integer.MAX_VALUE;
        int diffRight = Integer.MAX_VALUE;
        int colLeft = 0, colRight = 0;
        // search to the Left
        for (int col = colSpot; col > 0; col--) {
            if (parking[rowSpot][col] == 0) {
                diffLeft = colSpot - col;
                colLeft = col;
                break;
            }
        }
        // search to the Right
        for (int col = colSpot; col < parking[rowSpot].length; col++) {
            if (parking[rowSpot][col] == 0) {
                diffRight = col - colSpot;
                colRight = col;
                break;
            }
        }
        return diffLeft <= diffRight ? colLeft : colRight;
    }
}
