package g_StreamsFilesAndDirectories_Lab;

import java.io.*;

public class SerializeCustomObject {
    public static void main(String[] args) {

        String path = "src\\g_StreamsFilesAndDirectories_Lab\\save.ser";

        Cube cube = new Cube("green",15.3, 12.4, 3.0);

        try (FileOutputStream fos = new FileOutputStream(path);
             ObjectOutputStream oos = new ObjectOutputStream(fos)) {
            oos.writeObject(cube);

        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    static class Cube implements Serializable {
        String color;
        double width;
        double height;
        double depth;

        public Cube(String color, double width, double height, double depth) {
            this.color = color;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
    }
}
