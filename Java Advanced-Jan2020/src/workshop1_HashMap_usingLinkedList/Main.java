package workshop1_HashMap_usingLinkedList;

public class Main {
    public static void main(String[] args) {

        NodeList<String, String> list = new NodeList<>();

        Node<String, String> alice = new Node<>("Alice", "Sofia");
        Node<String, String> zoe = new Node<>("Zoe", "Brussels");
        Node<String, String> charlie = new Node<>("Charlie", "London");

        list.add(alice);
        list.add(zoe);
        list.add(charlie);

        Node<String, String> aliceGet = list.getFirstNodeWithKey("Alice");
        System.out.println(aliceGet);

//        System.out.println(list);
        for (Node<String, String> n : list) {
            System.out.println(n);
        }

//        GenericHashMap<String,String> map = new GenericHashMap<>();
//        map.put("Alice", "Sofia");
//        map.put("Zoe", "Brussels");
//        map.put("Charlie", "London");
//        map.put("Zoe", "Plovdiv");
//        map.put("Dylan", "Varna");
//        map.put("Elena", "Burgas");
//        map.put("Frank", "Novi Sad");
//        map.put("George", "Plovdiv");
//
//        String aliceValue = map.get("Alice");
//
//        System.out.println(aliceValue);
//        System.out.println(map);
//
//        GenericHashMap<Integer,Integer> inte = new GenericHashMap<>();
//        inte.put(1, 10);
//        inte.put(2, 20);
//        System.out.println(inte.get(2));
//        System.out.println(inte);
    }
}
