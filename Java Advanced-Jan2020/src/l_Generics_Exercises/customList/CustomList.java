package l_Generics_Exercises.customList;

import java.util.*;
import java.util.function.Consumer;

public class CustomList<E extends Comparable<E>> implements Iterable<E> {
    private static final int INITIAL_CAPACITY = 4;
    private Object[] elements;
    private int size;

    public CustomList() {
        this.elements = new Object[INITIAL_CAPACITY];
    }

    public void add(E element) {
        if (this.size == elements.length) {
            this.elements = grow();
        }
        this.elements[this.size] = element;
        this.size++;
    }

    public E get(int index) {
        verifyIndex(index);
        return getAtIndex(index);
    }

    @SuppressWarnings("unchecked")
    private E getAtIndex(int index) {
        return (E) this.elements[index];
    }

    public E remove(int index) {
        verifyIndex(index);

        E element = getAtIndex(index);

        shiftLeft(index);
        this.size--;

        return element;
    }

    public boolean contains(Object element) {
        for (Object o : this.elements) {
            if (element.equals(o)) {
                return true;
            }
        }
        return false;
    }

    public void swap(int index1, int index2) {
        verifyIndex(index1);
        verifyIndex(index2);

        Object temp = this.elements[index1];
        this.elements[index1] = this.elements[index2];
        this.elements[index2] = temp;
    }

    public int countGreaterThan(E element) {
        int counter = 0;

        for (int i = 0; i < this.size; i++) {
            if (getAtIndex(i).compareTo(element) > 0) {
                counter++;
            }
        }
        return counter;
    }

    public E getMax() {
        if (this.size == 0) {
            return null;
        }
        E max = getAtIndex(0);
        for (int i = 1; i < this.size; i++) {
            if (getAtIndex(i).compareTo(max) > 0) {
                max = getAtIndex(i);
            }
        }
        return max;
    }

    public E getMin() {
        if (this.size == 0) {
            return null;
        }

        E min = getAtIndex(0);
        for (int i = 1; i < this.size; i++) {
            if (getAtIndex(i).compareTo(min) < 0) {
                min = getAtIndex(i);
            }
        }
        return min;
    }

    public void print() {
        for (E e : this) {
            System.out.println(e);
        }
    }

    public void sort() {
        for (int i = 0; i < this.size; i++) {
            E element = this.getAtIndex(i);
            for (int j = 0; j < this.size - 1; j++) {
                if (element.compareTo(this.getAtIndex(j)) < 0) {
                    this.swap(i, j);
                }
            }
        }
    }

    private void shiftLeft(int index) {
        for (int i = index; i < this.size - 1; i++) {
            this.elements[i] = this.elements[i + 1];
        }
        this.elements[this.size - 1] = null;
    }


    private void verifyIndex(int index) {
        if (index < 0 || index >= this.size) {
            throw new IndexOutOfBoundsException("Index " + index + " is not valid!");
        }
    }

    private Object[] grow() {
        // Var2
//        Object[] copy = new Object[this.elements.length * 2];
//        for (int i = 0; i < this.elements.length; i++) {
//            copy[i] = this.elements[i];
//        }
//        return copy;
        return Arrays.copyOf(this.elements, this.elements.length * 2);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("[");
        if (this.size > 0) {
            for (int i = 0; i < this.size - 1; i++) {
                sb.append(this.elements[i]).append(", ");
            }
            sb.append(this.elements[this.size - 1]);
        }
        sb.append("]");
        return sb.toString();
    }

    @Override
    public Iterator<E> iterator() {
        return new Iterator<E>() {

            private int index = 0;

            @Override
            public boolean hasNext() {
                return index < size;
            }

            @Override
            public E next() {
                return getAtIndex(index++);
            }
        };
    }

    @Override
    public void forEach(Consumer<? super E> consumer) {
        for (E e : this) {
            consumer.accept(e);
        }
    }

}
