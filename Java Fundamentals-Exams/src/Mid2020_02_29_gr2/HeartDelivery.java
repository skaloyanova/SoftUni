package Mid2020_02_29_gr2;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class HeartDelivery {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] housesArr = sc.nextLine().split("@");
        List<Integer> houses = Arrays.stream(housesArr).map(Integer::parseInt).collect(Collectors.toList());

        String input = sc.nextLine();
        int index = 0;

        while (!"Love!".equals(input)) {
            String[] tokens = input.split("\\s+");
            int length = Integer.parseInt(tokens[1]);

            index += length;
            if (index >= houses.size()) {
                index = 0;
            }

            int currentHeart = houses.get(index);
            if (currentHeart > 0) {
                houses.set(index, currentHeart - 2);
                if (houses.get(index) == 0) {
                    System.out.printf("Place %d has Valentine's day.%n", index);
                }
            } else {
                System.out.printf("Place %d already had Valentine's day.%n", index);
            }

            input = sc.nextLine();
        }

        int count = 0;
        for (Integer house : houses) {
            if (house != 0) {
                count++;
            }
        }

        System.out.printf("Cupid's last position was %d.%n", index);
        if (count == 0) {
            System.out.println("Mission was successful.");
        } else {
            System.out.printf("Cupid has failed %d places.%n", count);
        }

    }
}
