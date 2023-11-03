package k_Generics_Lab;

public class Scale<T extends Comparable<T>> {
    private T left;
    private T right;

    public Scale(T left, T right) {
        this.left = left;
        this.right = right;
    }

    public T getHeavier() {
        int result = left.compareTo(right);
        if (result == 0) {
            return null;
        } else {
            return result > 0 ? left : right;
        }
    }
}
