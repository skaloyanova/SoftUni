package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Scanner;

public class xCarRace {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] inputArr = sc.nextLine().split("\\s+");
        ArrayList<Integer> data = new ArrayList<>();

        for (String e : inputArr) {
            data.add(Integer.parseInt(e));
        }

        double sumLeft = 0;
        double sumRight = 0;

        for (int i = 0; i < data.size() / 2; i++) {
            int indexLeft = i;
            int indexRight = data.size() - 1 - i;

            if (data.get(indexLeft) == 0) {
                sumLeft = sumLeft * 0.8;
            } else {
                sumLeft += data.get(indexLeft);
            }

            if (data.get(indexRight) == 0) {
                sumRight = sumRight * 0.8;
            } else {
                sumRight += data.get(indexRight);
            }
        }

        if (sumLeft < sumRight) {
            System.out.println(String.format("The winner is left with total time: %.1f", sumLeft));
        } else {
            System.out.println(String.format("The winner is right with total time: %.1f", sumRight));
        }
    }
}
