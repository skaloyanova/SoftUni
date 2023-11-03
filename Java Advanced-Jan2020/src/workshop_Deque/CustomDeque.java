package workshop_Deque;

import java.util.Arrays;
import java.util.NoSuchElementException;

public class CustomDeque {
    private int[] elements;
    private int head;
    private int tail;
    private static final int INITIAL_CAPACITY = 5;
    private int size;

    public CustomDeque() {
        this.elements = new int[INITIAL_CAPACITY];
        this.head = elements.length / 2;
        this.tail = elements.length / 2;
    }

    //stack: push(), pop(), peek()
    //queue: offer(), poll(), peek()

    public void push(int element) {
        if (this.head == 0) {
            this.elements = grow();
        }

        if (this.size == 0) {
            this.elements[this.head] = element;
        } else {
            this.elements[--this.head] = element;
        }

        this.size++;
    }

    public void offer(int element) {
        if (this.tail == this.elements.length - 1) {
            this.elements = grow();
        }

        if (this.size == 0) {
            this.elements[this.tail] = element;
        } else {
            this.elements[++this.tail] = element;
        }

        this.size++;
    }

    private int[] grow() {
        int newCapacity = this.elements.length * 3;
        int[] copy = new int[newCapacity];
        int positionToStart = (newCapacity - this.size) / 2;
        System.arraycopy(this.elements, this.head, copy, positionToStart, this.size);

        this.head = positionToStart;
        this.tail = positionToStart + this.size - 1;

        return copy;
    }

    public int peek() {
        return this.elements[this.head];
    }

    public int pop() {
        return removeFirst();
    }

    public int poll() {
        return removeFirst();

    }

    private int removeFirst() {
        if (size == 0) {
            throw new NoSuchElementException("deque is empty");
        }
        int element = this.elements[this.head];
        this.elements[this.head] = 0;
        this.head++;
        this.size--;

        if (this.size == 0) {
            this.elements = new int[INITIAL_CAPACITY];
            this.head = elements.length / 2;
            this.tail = elements.length / 2;
        }

        return element;
    }



    @Override
    public String toString() {
        return Arrays.toString(this.elements);
    }

}
