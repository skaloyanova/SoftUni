package workshop2_DoublyLinkedList;

public class Main {
    public static void main(String[] args) {

        DoublyLinkedList list = new DoublyLinkedList();
        list.addFirst(20);
        list.addFirst(10);
        list.addLast(30);
        list.addLast(40);
        list.addFirst(5);

        System.out.println(list);

//        System.out.print("first removed: " + list.removeFirst()); System.out.println("List: " + list);
//        System.out.print("first removed: " + list.removeFirst()); System.out.println("List: " + list);
//        System.out.print("first removed: " + list.removeFirst()); System.out.println("List: " + list);
//        System.out.print("first removed: " + list.removeFirst()); System.out.println("List: " + list);
//        System.out.print("first removed: " + list.removeFirst()); System.out.println("List: " + list);

        list.insertAfter(30, 35);
        list.insertAfter(40, 45);
        System.out.println(list);
    }
}
