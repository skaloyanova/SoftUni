package workshop_SmartArray_CustomStack;

import java.util.Arrays;
import java.util.NoSuchElementException;
import java.util.function.Consumer;

public class CustomStack {
    final static int INITIAL_CAPACITY = 4;
    private int capacity;
    private int size;
    private int[] items;

    public CustomStack() {
        this.capacity = INITIAL_CAPACITY;
        this.items = new int[this.capacity];
        this.size = 0;
    }

    public int size() {
        return this.size;
    }

    //Adds the given element to the stack
    public void push(int element) {
        if (this.size == this.capacity) {
            resize();
        }
        items[size++] = element;
    }

    //Removes the last added element
    public int pop() {
        if (this.size == 0) {
            throw new NoSuchElementException("Stack is empty");
        }

        int elementToRemove = this.items[this.size - 1];
        this.items[this.size - 1] = 0;
        size--;

        if (this.size <= capacity / 4) {
            shrink();
        }

        return elementToRemove;
    }

    private void shrink() {
        capacity /= 2;
        int[] copy = new int[capacity];
        for (int i = 0; i < this.size; i++) {
            copy[i] = items[i];
        }
        items = copy;
    }

    //Returns the last element in the stack without removing it
    public int peek() {
        if (this.size == 0) {
            throw new NoSuchElementException("Stack is empty");
        }
        return this.items[this.size - 1];
    }

    //Goes through each of the elements in the stack
    public void forEach(Consumer<Integer> consumer) {
        for (int i = this.size - 1; i >= 0; i++) {
            consumer.accept(this.items[i]);
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("{");
        for (int i = 0; i < this.size - 1; i++) {
            sb.append(this.items[i]).append(", ");
        }
        sb.append(this.items[this.size - 1]).append("}");
        return sb.toString();
    }

    public void printInternalStack() {
        System.out.println(Arrays.toString(this.items));
    }

    private void resize() {
        this.capacity *= 2;
        int[] copy = new int[this.capacity];
        for (int i = 0; i < this.size; i++) {
            copy[i] = this.items[i];
        }
        this.items = copy;

    }
}
