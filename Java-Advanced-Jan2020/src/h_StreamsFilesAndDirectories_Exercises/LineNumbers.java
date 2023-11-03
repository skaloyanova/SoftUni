package h_StreamsFilesAndDirectories_Exercises;

import java.io.*;

public class LineNumbers {
    public static void main(String[] args) {
        String pathIn = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\inputLineNumbers.txt";
        String pathOut = "src\\h_StreamsFilesAndDirectories_Exercises\\output.txt";

        try(BufferedReader in = new BufferedReader(new FileReader(pathIn));
            PrintWriter out = new PrintWriter(pathOut)) {
            int cnt = 1;
            String line = in.readLine();
            while (line != null) {
                out.println(cnt + ". " + line);
                line = in.readLine();
                cnt++;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
