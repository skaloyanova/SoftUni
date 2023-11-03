package g_StreamsFilesAndDirectories_Lab;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class WriteToFile {
    public static void main(String[] args) throws IOException {
        String pathIn = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\input.txt";
        String pathOut = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\02.WriteToFileOutput.txt";


        FileInputStream fis = new FileInputStream(pathIn);
        FileOutputStream fos = new FileOutputStream(pathOut);

        String punctuation = ",.!?";

        int oneByte = fis.read();
        while (oneByte >= 0) {
            if (!punctuation.contains("" + (char) oneByte)) {
                fos.write(oneByte);
            }
            oneByte = fis.read();
        }

    }
}
