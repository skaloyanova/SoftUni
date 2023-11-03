package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Scanner;

public class xDrumSet {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        double savings = Double.parseDouble(sc.nextLine());
        String[] drumSetArr = sc.nextLine().split("\\s+");

        ArrayList<Integer> drums = new ArrayList<>();

        for (String drum : drumSetArr) {
            drums.add(Integer.parseInt(drum));
        }

        ArrayList<Integer> initialDrums = new ArrayList<>(drums);

        String command = sc.nextLine();
        while (!"Hit it again, Gabsy!".equals(command)) {

            int power = Integer.parseInt(command);

            for (int i = 0; i < drums.size(); i++) {
                drums.set(i, (drums.get(i) - power));

                if (drums.get(i) <= 0) {
                    int drumCost = initialDrums.get(i) * 3;
                    if (drumCost <= savings) {
                        savings -= drumCost;
                        drums.set(i, initialDrums.get(i));
                    } else {
                        drums.remove(i);
                        initialDrums.remove(i);
                        i--;
                    }
                }
            }

            command = sc.nextLine();
        }

        for (Integer drum : drums) {
            System.out.print(drum + " ");
        }
        System.out.println();
        System.out.println(String.format("Gabsy has %.2flv.", savings));
    }

}
