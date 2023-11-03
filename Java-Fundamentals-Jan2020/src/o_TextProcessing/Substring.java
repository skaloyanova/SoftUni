package o_TextProcessing;

import java.util.Scanner;

public class Substring {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String pattern = sc.nextLine();
        String text = sc.nextLine();

        int patternLength = pattern.length();
        while(text.contains(pattern)) {
//            int first = text.indexOf(pattern);
//            text = text.substring(0, first) + text.substring(first + patternLength);
            text = text.replace(pattern,"");
        }
        System.out.println(text);
    }
}
