package i_polymorphism_Lab.shapes;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Shape> shapes = new ArrayList<>();

        shapes.add(new Rectangle(2.0, 3.0));
        shapes.add(new Circle(5.0));

        for (Shape shape : shapes) {
            System.out.println(shape.getPerimeter());
            System.out.println(shape.getArea());
        }
    }
}
