package a_workingWithAbstraction_Lab.pointInRectangle;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Rectangle rectangle = getRectangleFromFourIntsFromConsole(sc);

        int n = sc.nextInt();
        for (int i = 0; i < n; i++) {
            Point point = createPointFromTwoIntsFromConsole(sc);

            System.out.println(rectangle.contains(point));
        }
    }

    private static Rectangle getRectangleFromFourIntsFromConsole(Scanner sc) {
        Point bottomLeft = createPointFromTwoIntsFromConsole(sc);
        Point topRight = createPointFromTwoIntsFromConsole(sc);
        return new Rectangle(bottomLeft, topRight);
    }

    private static Point createPointFromTwoIntsFromConsole(Scanner sc) {
        int x = sc.nextInt();
        int y = sc.nextInt();
        return new Point(x, y);
    }
}
