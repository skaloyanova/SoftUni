package h_Methods_Exercise;

import java.util.Scanner;

public class xLongerLine {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int x1 = Integer.parseInt(sc.nextLine());
        int y1 = Integer.parseInt(sc.nextLine());
        int x2 = Integer.parseInt(sc.nextLine());
        int y2 = Integer.parseInt(sc.nextLine());

        int x11 = Integer.parseInt(sc.nextLine());
        int y11 = Integer.parseInt(sc.nextLine());
        int x22 = Integer.parseInt(sc.nextLine());
        int y22 = Integer.parseInt(sc.nextLine());

        double line1 = calculateLineLength(x1, y1, x2, y2);
        double line2 = calculateLineLength(x11, y11, x22, y22);

        if (line1 >= line2) {
            printCloserPoint(x1, y1, x2, y2);
        } else {
            printCloserPoint(x11, y11, x22, y22);
        }

    }

    private static double calculateLineLength(int x1, int y1, int x2, int y2) {
        int a = Math.abs(x1 - x2);
        int b = Math.abs(y1 - y2);

        return Math.sqrt(a * a + b * b);
    }

    private static void printCloserPoint(int x1, int y1, int x2, int y2) {
        double vector1 = Math.sqrt(x1 * x1 + y1 * y1);
        double vector2 = Math.sqrt(x2 * x2 + y2 * y2);

        if (vector1 <= vector2) {
            System.out.println(String.format("(%d, %d)(%d, %d)", x1, y1, x2, y2));
        } else {
            System.out.println(String.format("(%d, %d)(%d, %d)", x2, y2, x1, y1));
        }
    }
}
