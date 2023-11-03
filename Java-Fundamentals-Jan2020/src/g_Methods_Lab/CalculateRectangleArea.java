package g_Methods_Lab;

import java.util.Scanner;

public class CalculateRectangleArea {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double width = Double.parseDouble(sc.nextLine());
        double length = Double.parseDouble(sc.nextLine());

        double area = getRectangleArea(width, length);
        System.out.printf("%.0f", area);
    }

    private static double getRectangleArea(double width, double length) {
        return width * length;
    }
}
