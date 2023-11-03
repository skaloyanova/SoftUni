package workshop1_HashMap_usingLinkedList;

public class GenericHashMap<K, V> {
    private NodeList[] buckets;
    private static final int INITIAL_CAPACITY = 4;
    private static final double LOAD_FACTOR = 0.5;
    private int size;

    public GenericHashMap() {
        this.buckets = new NodeList[INITIAL_CAPACITY];
        this.size = 0;
    }

    public boolean containsKey(K key){
        V value = this.get(key);
        return value != null;
    }

    public void put(K key, V value) {

//        resizeWhenNeeded();

        // get bucket key
        int bucketIndex = getBucketIndex(key);

        // if bucket is never used, initialize it with empty list
        if (buckets[bucketIndex] == null) {
            buckets[bucketIndex] = new NodeList<K, V>();
        }

        // get the bucket list, where element should be added
        NodeList<K, V> currentBucket = this.buckets[bucketIndex];

        //check if such key exists
        Node<K, V> existing = currentBucket.getFirstNodeWithKey(key);

        // if there is no such key
        if (existing == null) {
            // create obj of type 'Node' with key and value
            Node<K, V> nodeToPut = new Node<>(key, value);
            // add element to the bucket
            currentBucket.add(nodeToPut);
            size++;
            return;
        }

        //if key exists, remove existing and add new Node to bucket list
        currentBucket.overrideNodeWithKey(key, value);
    }

    //TODO
//    private void resizeWhenNeeded() {
//        if (size < LOAD_FACTOR * buckets.length) {
//            return;
//        }
//        NodeList[] newBuckets = new NodeList[buckets.length * 2];
//        for (NodeList existingList : buckets) {
//            Node currentNode = existingList.getFirstElement();
//            Node nodeToTransfer = currentNode;
//            while (currentNode != null) {
//                int bucketIndex = Math.abs(nodeToTransfer.key.hashCode()) % newBuckets.length;
//                if (newBuckets[bucketIndex] == null) {
//                    newBuckets[bucketIndex] = new NodeList();
//                }
//                NodeList currentBucket = newBuckets[bucketIndex];
//                currentBucket.add(nodeToTransfer);
//                currentNode = currentNode.next;
//            }
//        }
//        this.buckets = newBuckets;
//    }

    public V get(K key) {
        int bucketIndex = getBucketIndex(key);
        NodeList<K, V> bucketList = buckets[bucketIndex];

        if (bucketList == null) {
            return null;
        }

        Node<K, V> requestedNode = bucketList.getFirstNodeWithKey(key);
        if (requestedNode == null) {
            return null;
        }
        return requestedNode.getValue();
    }

    private int getBucketIndex(K key) {
        return Math.abs(key.hashCode()) % buckets.length;
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (NodeList bucket : buckets) {
            sb.append(bucket).append(System.lineSeparator());
        }
        return sb.toString();
    }
}
