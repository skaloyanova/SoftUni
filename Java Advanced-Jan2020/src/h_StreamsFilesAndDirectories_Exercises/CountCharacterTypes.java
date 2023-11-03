package h_StreamsFilesAndDirectories_Exercises;

import java.io.*;

public class CountCharacterTypes {
    public static void main(String[] args) {
        String pathIn = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\input.txt";
        String pathOut = "src\\h_StreamsFilesAndDirectories_Exercises\\output.txt";

        int vowelCnt = 0;
        int consonantsCnt = 0;
        int punctuationCnt = 0;

        try (BufferedReader br = new BufferedReader(new FileReader(pathIn))) {
            String vowels = "aeiou";
            String punctuation = "!,.?";

            String inputLine = br.readLine();
            while (inputLine != null) {
                char[] line = inputLine.toCharArray();
                for (char c : line) {
                    if (vowels.contains(String.valueOf(c))) {
                        vowelCnt++;
                    } else if (punctuation.contains(String.valueOf(c))) {
                        punctuationCnt++;
                    } else if (c == ' ') {

                    } else {
                        consonantsCnt++;
                    }
                }
                inputLine = br.readLine();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (PrintWriter out = new PrintWriter(pathOut)){
            out.println("Vowels: " + vowelCnt);
            out.println("Consonants: " + consonantsCnt);
            out.println("Punctuation: " + punctuationCnt);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
