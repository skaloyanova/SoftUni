package i_polymorphism_Lab.shapes;

public class Rectangle extends Shape {
    private final Double height;
    private final Double width;

    public Rectangle(Double height, Double width) {
        this.height = height;
        this.width = width;
    }

    public Double getHeight() {
        return height;
    }

    public Double getWidth() {
        return width;
    }

    @Override
    protected Double calculatePerimeter() {
        return 2 * (height + width);
    }

    @Override
    protected Double calculateArea() {
        return height * width;
    }
}
