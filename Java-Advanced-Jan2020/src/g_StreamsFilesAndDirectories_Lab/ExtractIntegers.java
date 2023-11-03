package g_StreamsFilesAndDirectories_Lab;

import java.io.*;
import java.util.Scanner;

public class ExtractIntegers {
    public static void main(String[] args) throws IOException {

        String pathIn = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\input.txt";
        String pathOut = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\04.ExtractIntegersOutput.txt";

        try(
            FileInputStream fis = new FileInputStream(pathIn);
            FileOutputStream fos = new FileOutputStream(pathOut);
            Scanner sc = new Scanner(fis);
            PrintWriter out = new PrintWriter(fos)) {

            while (sc.hasNext()) {
                if (sc.hasNextInt()) {
                    out.println(sc.nextInt());
                } else {
                    sc.next();
                }
            }
        }
    }
}
