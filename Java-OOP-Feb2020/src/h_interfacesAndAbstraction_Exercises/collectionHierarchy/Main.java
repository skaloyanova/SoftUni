package h_interfacesAndAbstraction_Exercises.collectionHierarchy;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyListImpl myList = new MyListImpl();


        Scanner sc = new Scanner(System.in);
        String[] split = sc.nextLine().split("\\s+");

        String addCollString = "";
        String addRemoveCollString = "";
        String myListString = "";

        for (String s : split) {
            addCollString += addCollection.add(s) + " ";
            addRemoveCollString += addRemoveCollection.add(s) + " ";
            myListString += myList.add(s) + " ";
        }

        int removeCount = Integer.parseInt(sc.nextLine());

        System.out.println(addCollString);
        System.out.println(addRemoveCollString);
        System.out.println(myListString);

        addCollString = "";
        addRemoveCollString = "";
        myListString = "";

        for (int i = 0; i < removeCount; i++) {
            addRemoveCollString += addRemoveCollection.remove() + " ";
            myListString += myList.remove() + " ";
        }

        System.out.println(addRemoveCollString);
        System.out.println(myListString);
    }
}
