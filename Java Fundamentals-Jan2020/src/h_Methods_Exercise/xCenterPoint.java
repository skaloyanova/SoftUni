package h_Methods_Exercise;

import java.util.Scanner;

public class xCenterPoint {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int x1 = Integer.parseInt(sc.nextLine());
        int y1 = Integer.parseInt(sc.nextLine());
        int x2 = Integer.parseInt(sc.nextLine());
        int y2 = Integer.parseInt(sc.nextLine());

        printCloserPoint(x1, y1, x2, y2);
    }

    private static void printCloserPoint(int x1, int y1, int x2, int y2) {
        double vector1 = Math.sqrt(x1 * x1 + y1 * y1);
        double vector2 = Math.sqrt(x2 * x2 + y2 * y2);

        if (vector1 <= vector2) {
            System.out.println(String.format("(%d, %d)", x1, y1));
        } else {
            System.out.println(String.format("(%d, %d)", x2, y2));
        }
    }
}
