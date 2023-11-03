package h_StreamsFilesAndDirectories_Exercises;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class SumBytes {
    public static void main(String[] args) {
        String pathIn = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\input.txt";

        long sum = 0L;

        try(BufferedReader br = new BufferedReader(Files.newBufferedReader(Paths.get(pathIn)))) {
            String currentLine = br.readLine();
            while (currentLine != null) {
                for (int i = 0; i < currentLine.length(); i++) {
                    sum += currentLine.charAt(i);
                }


                currentLine = br.readLine();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println(sum);
    }
}
