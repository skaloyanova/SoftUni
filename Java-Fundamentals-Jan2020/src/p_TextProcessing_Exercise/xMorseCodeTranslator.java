package p_TextProcessing_Exercise;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class xMorseCodeTranslator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, String> morseCodes = new HashMap<>() {{
            put(".-", "A");
            put("-...", "B");
            put("-.-.", "C");
            put("-..", "D");
            put(".", "E");
            put("..-.", "F");
            put("--.", "G");
            put("....", "H");
            put("..", "I");
            put(".---", "J");
            put("-.-", "K");
            put(".-..", "L");
            put("--", "M");
            put("-.", "N");
            put("---", "O");
            put(".--.", "P");
            put("--.-", "Q");
            put(".-.", "R");
            put("...", "S");
            put("-", "T");
            put("..-", "U");
            put("...-", "V");
            put(".--", "W");
            put("-..-", "X");
            put("-.--", "Y");
            put("--..", "Z");
        }};

        String[] words = sc.nextLine().split(" \\| ");

        StringBuilder result = new StringBuilder();

        for (String word : words) {
            String[] letters = word.split(" ");
            for (String letter : letters) {
                result.append(morseCodes.get(letter));
            }
            result.append(" ");
        }
        System.out.println(result);
    }
}
