package h_StreamsFilesAndDirectories_Exercises;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class MergeTwoFiles {
    public static void main(String[] args) throws IOException {
        Path pathFile1 = Paths.get("src\\h_StreamsFilesAndDirectories_Exercises\\resources\\inputOne.txt");
        Path pathFile2 = Paths.get("src\\h_StreamsFilesAndDirectories_Exercises\\resources\\inputTwo.txt");

        String pathMerged = "src\\h_StreamsFilesAndDirectories_Exercises\\merged.txt";
        copyFileContent(pathFile1, pathMerged);
        copyFileContent(pathFile2, pathMerged);
    }

    private static void copyFileContent(Path pathFile1, String pathMerged) throws IOException {
        Files.readAllLines(pathFile1)
                .forEach(l -> {
                    try (PrintWriter pw = new PrintWriter(new FileWriter(pathMerged, true))) {
                        pw.println(l);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                });
    }
}
