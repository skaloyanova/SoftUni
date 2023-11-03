package g_StreamsFilesAndDirectories_Lab;

import java.io.FileInputStream;
import java.io.IOException;

public class ReadFile {
    public static void main(String[] args) throws IOException {
        String path = "D:\\Java Projects\\Advanced-Jan2020\\src\\g_StreamsFilesAndDirectories_Lab\\resources\\input.txt";

        FileInputStream fis = new FileInputStream(path);

        int oneByte = fis.read();
        while (oneByte != -1) {
            System.out.print(Integer.toBinaryString(oneByte) + " ");
            oneByte = fis.read();
        }

    }
}
