
package workshop2_DoublyLinkedList;

import java.util.NoSuchElementException;

public class DoublyLinkedList {

    // Node class
    private static class Node {
        private int element;
        private Node prev;
        private Node next;

        public Node(int element) {
            this.element = element;
        }

        @Override
        public String toString() {
            return String.valueOf(this.element);
        }
    }

    // List fields
    private Node head;
    private Node tail;
    private int size;

    public DoublyLinkedList() {
    }

    //adds an element at the beginning of the collection
    public void addFirst(int element) {
        Node first = new Node(element);
        this.size++;

        if (this.head == null) {
            this.head = first;
            this.tail = first;
            return;
        }
        first.next = this.head;
        this.head.prev = first;
        this.head = first;

    }

    // adds an element at the end of the collection
    public void addLast(int element) {
        Node last = new Node(element);
        this.size++;

        if (this.tail == null) {
            this.head = last;
            this.tail = last;
            return;
        }

        last.prev = this.tail;
        this.tail.next = last;
        this.tail = last;
    }

    // removes the element at the beginning of the collection
    public int removeFirst() {
        if (this.size == 0) {
            throw new NoSuchElementException("List is empty");
        }

        int removed = this.head.element;
//        Node first = this.head;     // for TEST purpose, to check if there is hanging reference

        if (this.size == 1) {
           this.head = null;
           this.tail = null;
        } else {
            this.head = this.head.next;
            this.head.prev.next = null;
            this.head.prev = null;
        }

        this.size--;
        return removed;
    }

    // removes the element at the end of the collection
    public int removeLast() {
        if (this.size == 0) {
            throw new NoSuchElementException("List is empty");
        }

        int removed = this.tail.element;
//        Node last = this.tail;      // for TEST purpose, to check if there is hanging reference

        if (this.size == 1) {
            this.tail = null;
            this.head = null;
        } else {
            this.tail = this.tail.prev;
            this.tail.next.prev = null;
            this.tail.next = null;
        }

        this.size--;
        return removed;

    }

    public int size() {
        return this.size;
    }

    public boolean insertAfter(int nodeValue, int element) {
        Node current = this.head;

        while (current != null) {
            if (current.element == nodeValue) {
                if (current.next == null) {
                    this.addLast(element);
                    return true;
                }

                Node newNode = new Node(element);

                newNode.next = current.next;
                newNode.prev = current;
                current.next.prev = newNode;
                current.next = newNode;
                size++;
                return true;
            }
            current = current.next;
        }
        return false;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        Node current = this.head;
        while (current != null) {
            sb.append(current).append(" ");
            current = current.next;
        }
        sb.append("size: ").append(this.size);
        return sb.toString();
    }

}
