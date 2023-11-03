package l_Generics_Exercises;

public class Box <T extends Comparable<T>> implements Comparable<Box<T>> {
    private T element;

    public Box(T element) {
        this.element = element;
    }

    @Override
    public String toString() {
        return this.element.getClass().getName() + ": " + this.element;
    }

    @Override
    public int compareTo(Box<T> other) {
        return this.element.compareTo(other.getElement());
    }

    public T getElement() {
        return this.element;
    }
}
