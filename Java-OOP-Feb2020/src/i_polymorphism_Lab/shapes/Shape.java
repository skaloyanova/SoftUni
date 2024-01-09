package i_polymorphism_Lab.shapes;

public abstract class Shape {
    private Double perimeter;
    private Double area;

    public Double getPerimeter() {              //Lazy loading
        if (perimeter == null) {
            perimeter = calculatePerimeter();
        }
        return perimeter;
    }

    public Double getArea() {
        if (area == null) {
            area = calculateArea();
        }
        return area;
    }

    protected abstract Double calculatePerimeter();

    protected abstract Double calculateArea();
}
