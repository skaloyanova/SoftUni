package g_StreamsFilesAndDirectories_Lab;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class CopyBytes {
    public static void main(String[] args) throws IOException {
        String pathIn = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\input.txt";
        String pathOut = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\03.CopyBytesOutput.txt";

        FileInputStream in = new FileInputStream(pathIn);
        FileOutputStream out = new FileOutputStream(pathOut);

        int space = ' ';
        int newLine = '\n';
//        int carriageReturn = '\r';
        int oneByte = in.read();
        while (oneByte >= 0) {
            String oneByteToString = String.valueOf(oneByte);
            if (oneByte == space || oneByte == newLine) {
                out.write((char)oneByte);
            } else {
                for (int i = 0; i < oneByteToString.length(); i++) {
                    out.write(oneByteToString.charAt(i));
                }
            }
            oneByte = in.read();
        }
    }
}
