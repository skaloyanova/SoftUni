package h_StreamsFilesAndDirectories_Exercises;

import java.io.*;
import java.util.ArrayList;

public class SerializeArrayList {
    public static void main(String[] args) throws IOException, ClassNotFoundException {
        ArrayList<Integer> list = new ArrayList<>();
        for (int i = 0; i < 50; i++) {
            list.add(i);
        }
        String path = "src\\h_StreamsFilesAndDirectories_Exercises\\list.ser";
        FileOutputStream fos = new FileOutputStream(path);
        ObjectOutputStream oos = new ObjectOutputStream(fos);
        oos.writeObject(list);

        ObjectInputStream ois = new ObjectInputStream(new FileInputStream(path));
        ArrayList<Integer> listDeSer = new ArrayList<>();
        System.out.println(listDeSer);
        listDeSer = (ArrayList<Integer>) ois.readObject();
        System.out.println(listDeSer);
    }
}
