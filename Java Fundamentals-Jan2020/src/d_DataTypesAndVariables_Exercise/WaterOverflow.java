package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class WaterOverflow {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        int tankCapacity = 0;

        for (int i = 0; i < n; i++) {
            int water = Integer.parseInt(sc.nextLine());

            tankCapacity += water;
            if (tankCapacity > 255) {
                System.out.println("Insufficient capacity!");
                tankCapacity -= water;
            }
        }
        System.out.println(tankCapacity);
    }
}
