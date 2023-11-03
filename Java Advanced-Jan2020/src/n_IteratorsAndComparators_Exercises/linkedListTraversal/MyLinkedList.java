package n_IteratorsAndComparators_Exercises.linkedListTraversal;

import java.util.Iterator;

public class MyLinkedList<E> implements Iterable<E> {

    private Node<E> firstNode;
    private Node<E> lastNode;
    private int size;

    public void add(E element) {
        Node<E> newNode = new Node<>(element);
        size++;
        if (firstNode == null) {
            firstNode = lastNode = newNode;
            return;
        }

        lastNode.next = newNode;
        lastNode = newNode;
    }

    public boolean remove(E element) {
        if (firstNode.element == element) {
            firstNode = firstNode.next;
            size--;
            return true;
        }

        Node<E> currentNode = firstNode;
        while (currentNode.next != null) {
            if (currentNode.next.element == element) {
                Node<E> nextElement = currentNode.next;
                currentNode.next = nextElement.next;
                nextElement.next = null;
                size--;
                return true;
            }
            currentNode = currentNode.next;
        }

        return false;
    }

    public int getSize() {
        return this.size;
    }

    @Override
    public Iterator<E> iterator() {
        return new Iterator<>() {
            Node<E> currentNode = firstNode;

            @Override
            public boolean hasNext() {
                return currentNode != null;
            }

            @Override
            public E next() {
                E currentElement = currentNode.element;
                currentNode = currentNode.next;
                return currentElement;
            }
        };
    }

    public static class Node<E> {
        private E element;
        private Node<E> next;

        public Node(E element) {
            this.element = element;
        }

        @Override
        public String toString() {
            return String.valueOf(this.element);
        }
    }
}
