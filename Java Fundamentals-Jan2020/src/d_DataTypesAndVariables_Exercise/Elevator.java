package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class Elevator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int peopleCnt = Integer.parseInt(sc.nextLine());
        int elevatorCapacity = Integer.parseInt(sc.nextLine());

        int courses = (int) Math.ceil(1.0 * peopleCnt / elevatorCapacity);

        System.out.printf("%d", courses);
    }
}
