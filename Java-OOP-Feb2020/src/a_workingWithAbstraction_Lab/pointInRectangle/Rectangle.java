package a_workingWithAbstraction_Lab.pointInRectangle;

public class Rectangle {
    private Point bottomLeft;
    private Point topRight;

    public Rectangle(Point bottomLeft, Point topRight) {
        this.bottomLeft = bottomLeft;
        this.topRight = topRight;
    }

    public boolean contains(Point point) {
        int pointX = point.getX();
        int pointY = point.getY();

        boolean withinVertical = pointY >= bottomLeft.getY() && pointY <= topRight.getY();
        boolean withinHorizontal = pointX >= bottomLeft.getX() && pointX <= topRight.getX();

        return withinHorizontal && withinVertical;
    }
}
