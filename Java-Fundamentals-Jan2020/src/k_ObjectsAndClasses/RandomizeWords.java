package k_ObjectsAndClasses;

import java.util.Random;
import java.util.Scanner;

public class RandomizeWords {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] words = sc.nextLine().split("\\s+");

        randomizeWords(words);

        for (String word : words) {
            System.out.println(word);
        }
    }

    private static void randomizeWords(String[] words) {
        for (int i = 0; i < words.length; i++) {
            Random rnd = new Random();
            int swapIndex = rnd.nextInt(words.length);
            String temp = words[i];
            words[i] = words[swapIndex];
            words[swapIndex] = temp;
        }
    }

}
