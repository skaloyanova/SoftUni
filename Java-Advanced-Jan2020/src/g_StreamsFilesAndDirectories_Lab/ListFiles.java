package g_StreamsFilesAndDirectories_Lab;

import java.io.File;
import java.io.IOException;

public class ListFiles {
    public static void main(String[] args) throws IOException {
        String startFolder = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\Files-and-Streams";
        File fileOrDir = new File(startFolder);
        File[] files = fileOrDir.listFiles(File::isFile);

        if (files != null) {
            for (File file : files) {
                System.out.println(String.format("%s: [%d]", file.getName(), file.length()));
            }
        }

    }
}
