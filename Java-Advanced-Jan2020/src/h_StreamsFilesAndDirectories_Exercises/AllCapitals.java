package h_StreamsFilesAndDirectories_Exercises;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;

public class AllCapitals {
    public static void main(String[] args) {
        String pathIn = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\input.txt";
        String pathOut = "src\\h_StreamsFilesAndDirectories_Exercises\\output.txt";

        try (BufferedReader br = new BufferedReader(new FileReader(pathIn));
             PrintWriter print = new PrintWriter(pathOut)) {
            String line = br.readLine();
            while (line != null) {
                String upperCase = line.toUpperCase();
                print.println(upperCase);
                line = br.readLine();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
