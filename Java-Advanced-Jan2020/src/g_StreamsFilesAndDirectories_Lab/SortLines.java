package g_StreamsFilesAndDirectories_Lab;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Collections;
import java.util.List;

public class SortLines {
    public static void main(String[] args) throws IOException {
        Path pathIn = Paths.get("src\\g_StreamsFilesAndDirectories_Lab\\resources\\input.txt");
        Path pathOut = Paths.get("src\\g_StreamsFilesAndDirectories_Lab\\resources\\06.SortLinesOutput.txt");

        List<String> lines = Files.readAllLines(pathIn);
        Collections.sort(lines);
        Files.write(pathOut, lines);
    }
}
