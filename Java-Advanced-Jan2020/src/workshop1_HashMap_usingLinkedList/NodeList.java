package workshop1_HashMap_usingLinkedList;

import java.util.Iterator;

public class NodeList<K, V> implements Iterable<Node<K,V>>{
    private Node<K, V> firstElement;

    public void add(Node<K, V> node) {
        if (firstElement == null) {
            firstElement = node;
            return;
        }
        Node<K, V> currentNode = firstElement;
        while (true) {
            if (currentNode.next == null) {
                currentNode.next = node;
                return;
            }
            currentNode = currentNode.next;
        }
    }

    public Node<K, V> getFirstNodeWithKey(K key) {

        Node<K, V> currentNode = firstElement;
        while (currentNode != null) {
            if (key.equals(currentNode.key)) {
                return currentNode;
            }
            currentNode = currentNode.next;
        }
        return null;
    }

    @Override
    public String toString() {
        if (firstElement == null) {
            return "[]";
        }
        StringBuilder sb = new StringBuilder();
        Node<K, V> currentNode = firstElement;
        while (currentNode != null) {
            sb.append("{").append(currentNode).append("}").append(" ");
            currentNode = currentNode.next;
        }
        return sb.toString();
    }

    public Node<K, V> getFirstElement(){
        return this.firstElement;
    }

    public void overrideNodeWithKey(K key, V value) {
        Node<K, V> existing = getFirstNodeWithKey(key);
        Node<K, V> newNode = new Node<>(key, value);

        // if list is empty
        if (firstElement == null) {
            return;
        }

        // if firstElement should be updated
        if (firstElement == existing) {
            newNode.next = firstElement.next;
            firstElement = newNode;
            return;
        }
        // if not the first element should be updated
        Node<K, V> currentNode = firstElement;
        while (currentNode != null) {
            if (currentNode.next == existing) {
                newNode.next = existing.next;
                currentNode.next = newNode;
                return;
            }
            currentNode = currentNode.next;
        }
    }

    @Override
    public Iterator<Node<K, V>> iterator() {
        return new Iterator<Node<K,V>>() {
            Node<K,V> currentNode = firstElement;

            @Override
            public boolean hasNext() {
                return currentNode.next != null;
            }

            @Override
            public Node<K,V> next() {
                currentNode = currentNode.next;
                return currentNode;
            }
        };
    }
}
