package p_TextProcessing_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class xTreasureFinder {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] key = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        String text = sc.nextLine();

        while (!"find".equals(text)) {
            StringBuilder decrypted = new StringBuilder();
            for (int i = 0; i < text.length(); i++) {
                char newChar = (char) (text.charAt(i) - key[i % key.length]);
                decrypted.append(newChar);
            }

            String item = decrypted.substring(decrypted.indexOf("&") + 1, decrypted.lastIndexOf("&"));;
            String coordinates = decrypted.substring(decrypted.indexOf("<") + 1, decrypted.indexOf(">"));
            System.out.println(String.format("Found %s at %s",item, coordinates));

            text = sc.nextLine();
        }

    }
}
