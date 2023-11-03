package n_IteratorsAndComparators_Exercises.stack;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class Stack implements Iterable<Integer> {

    public static class Node {
        private Node next;
        private int element;

        public Node(int element) {
            this.element = element;
            this.next = null;
        }

        @Override
        public String toString() {
            return String.valueOf(this.element);
        }
    }

    private Node top;

    public void push(int... elements) {
        for (int value : elements) {
            Node newNode = new Node(value);
            newNode.next = top;
            top = newNode;
        }
    }

    public int pop() {
        if (top == null) {
            throw new NoSuchElementException("No elements");
        }
        Node nodeToReturn = top;
        top = top.next;
        nodeToReturn.next = null;
        return nodeToReturn.element;
    }

    @Override
    public Iterator<Integer> iterator() {
        return new Iterator<Integer>() {

            Node nodeToStart = top;

            @Override
            public boolean hasNext() {
                if (nodeToStart == null) {
                    nodeToStart = top;
                    return false;
                }
                return true;
            }

            @Override
            public Integer next() {
                Integer next = nodeToStart.element;
                nodeToStart = nodeToStart.next;
                return next;
            }
        };
    }
}
