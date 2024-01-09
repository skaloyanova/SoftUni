package i_polymorphism_Lab.shapes;

public class Circle extends Shape {
    private final Double radius;

    public Circle(Double radius) {
        this.radius = radius;
    }

    public final Double getRadius() {
        return radius;
    }

    @Override
    protected Double calculatePerimeter() {
        return 2 * Math.PI * radius;
    }

    @Override
    protected Double calculateArea() {
        return Math.pow(Math.PI * radius , 2);
    }
}
