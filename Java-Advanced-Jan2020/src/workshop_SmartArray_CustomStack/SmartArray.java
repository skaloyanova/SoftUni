package workshop_SmartArray_CustomStack;

import java.util.Arrays;
import java.util.function.Consumer;

public class SmartArray {
    private static final int INITIAL_CAPACITY = 4;
    private int[] data;
    private int size;       //actual size (number of present members
    private int capacity;

    public SmartArray() {
        this.data = new int[INITIAL_CAPACITY];
        this.capacity = INITIAL_CAPACITY;
        this.size = 0;
    }

    // Adds the given element to the end of the list
    public void add(int element) {
        if (this.size == this.capacity) {
            this.resize();
        }
        this.data[this.size++] = element;
    }

    // Returns the element at the specified position in this list
    public int get(int index) {
        // checks if index is valid, and if it is not, throws exception
        checkIndex(index);

        return this.data[index];
    }

    private void checkIndex(int index) {
        if (index < 0 || index >= this.size) {
            String message = String.format("Index %d out of bounds for length %d", index, this.size);
            throw new IndexOutOfBoundsException(message);
        }
    }

    // Removes the element at the given index
    public int remove(int index) {
        checkIndex(index);

        int element = this.data[index];
        shiftLeft(index);
        this.size--;

        shrinkWhenNeeded();
        return element;
    }

    public int size() {
        return this.size;
    }

    // Checks if the list contains the given element returns (True or False)
    public boolean contains(int element) {
        for (int member: data) {
            if (member == element) {
                return true;
            }
        }
        return false;
    }

    // Adds element at the specific index, the element at this index gets shift to the right alongside
    // with any following elements, increasing size
    public void add(int index, int element) {
        checkIndex(index);

        shiftRight(index);
        this.data[index] = element;
        this.size++;
    }

    // Goes through each one of the elements in the list
    public void forEach(Consumer<Integer> consumer) {
        for (int i = 0; i < this.size; i++) {
            consumer.accept(this.data[i]);
        }
    }

    // this method will be used to increase the internal collection's length twice
    private void resize() {
        this.capacity *= 2;
        int[] newData = new int[this.capacity];
        for (int i = 0; i < data.length; i++) {
            newData[i] = this.data[i];
        }
        this.data = newData;
    }

    // this method will help us to decrease the internal collection's length twice
    private void shrinkWhenNeeded() {
        if (this.size > capacity / 4) {
            return;
        }
        this.capacity /= 2;
        int[] newData = new int[this.capacity];

        for (int i = 0; i < this.size; i++) {
            newData[i] = this.data[i];
        }
        this.data = newData;
    }

    // this method will help us to rearrange the internal collection's elements after removing one
    private void shiftLeft(int index) {
        for (int i = index; i < this.size - 1; i++) {
            this.data[i] = this.data[i + 1];
        }
        this.data[this.size - 1] = 0;
    }

    // this method we will use when we inset element at specific index
    private void shiftRight(int index) {
        if (this.size == this.capacity) {
            resize();
        }

        for (int i = this.size - 1; i >= index; i--) {
            this.data[i + 1] = this.data[i];
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("[");
        for (int i = 0; i < this.size - 1; i++) {
            sb.append(this.data[i]).append(", ");
        }
        sb.append(this.data[this.size - 1]).append("]");
        return sb.toString();
    }

    public String printInternalArray() {
        return Arrays.toString(data);
    }
}
