package workshop1_HashMap_usingLinkedList;

public class Node<K, V> {
    final K key;
    final V value;
    Node<K, V> next = null;

    public Node(K key, V value) {
        this.key = key;
        this.value = value;
    }

    public V getValue() {
        return value;
    }

    public K getKey() {
        return key;
    }

    @Override
    public String toString() {
        return "k:" + this.key + " <> v:" + this.value;
    }

}
