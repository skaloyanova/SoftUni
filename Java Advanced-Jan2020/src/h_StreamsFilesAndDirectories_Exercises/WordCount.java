package h_StreamsFilesAndDirectories_Exercises;

import java.io.*;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.stream.Collectors;

public class WordCount {
    public static void main(String[] args) throws IOException {
        String pathFrom = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\words.txt";
        String pathIn = "src\\h_StreamsFilesAndDirectories_Exercises\\resources\\text.txt";
        String pathOut = "src\\h_StreamsFilesAndDirectories_Exercises\\output.txt";

        // Add the words to search for in a Map
        Map<String,Integer> wordsCnt = new HashMap<>();

        BufferedReader br = new BufferedReader(new FileReader(pathFrom));
        String line = br.readLine();
        while (line != null) {
            String[] tokens = line.split("\\s+");
            for (String token : tokens) {
                wordsCnt.put(token, 0);
            }
            line = br.readLine();
        }
        br.close();

        // Check who many times the words from the Map are present in the 2nd file
        BufferedReader in = new BufferedReader(new FileReader(pathIn));

        line = in.readLine();
        while (line != null) {
            String[] tokens = line.split("\\s+");
            for (String token : tokens) {
                if (wordsCnt.containsKey(token)) {
                    wordsCnt.put(token, wordsCnt.get(token) + 1);
                }
            }
            line = in.readLine();
        }
        in.close();

        // Sort the Map and print the results to file

        PrintWriter out = new PrintWriter(pathOut);
        wordsCnt.entrySet().stream()
                .sorted((c1,c2) -> c2.getValue().compareTo(c1.getValue()))
                .forEach(e -> {
                    out.println(e.getKey() + " - " + e.getValue());
                });
        out.close();
    }
}
