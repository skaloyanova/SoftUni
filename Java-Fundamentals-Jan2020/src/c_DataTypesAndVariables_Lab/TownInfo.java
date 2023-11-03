package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class TownInfo {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String town = sc.nextLine();
        int population = Integer.parseInt(sc.nextLine());
        int area = Integer.parseInt(sc.nextLine());

        System.out.println(String.format("Town %s has population of %d and area %d square km.", town, population, area));

    }
}
