package g_StreamsFilesAndDirectories_Lab;

import java.io.*;
import java.util.Scanner;

public class WriteEveryThirdLine {
    public static void main(String[] args) throws IOException {

        String pathIn = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\input.txt";
        String pathOut = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\05.WriteEveryThirdLineOutput.txt";

        //var-1 with Scanner
//        try (FileInputStream in = new FileInputStream(pathIn);
//             FileOutputStream out = new FileOutputStream(pathOut);
//             Scanner sc = new Scanner(in);
//             PrintWriter print = new PrintWriter(out)) {
//
//            int counter = 1;
//            while (sc.hasNextLine()) {
//                if (counter % 3 == 0) {
//                    print.println(sc.nextLine());
//                } else {
//                    sc.nextLine();
//                }
//                counter++;
//            }
//        }
        //var-2 with BufferReader
        try (BufferedReader br = new BufferedReader(new FileReader(pathIn));
             PrintWriter print = new PrintWriter(new FileWriter(pathOut))) {

            int counter = 1;
            String line = br.readLine();
            while (line != null) {
                if (counter % 3 == 0) {
                    print.println(line);
                }
                counter++;
                line = br.readLine();
            }
        }
    }
}
