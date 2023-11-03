package h_StreamsFilesAndDirectories_Exercises;

import java.io.File;

public class GetFolderSize {
    public static void main(String[] args) {
        String path = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\Exercises Resources";

        File folder = new File(path);
        long size = 0;
        for (File file : folder.listFiles()) {
            size += file.length();
        }

        System.out.println("Folder size: " + size);
    }
}
