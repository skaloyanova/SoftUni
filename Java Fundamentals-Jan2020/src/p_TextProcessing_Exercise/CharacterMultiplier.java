package p_TextProcessing_Exercise;

import java.util.Scanner;

public class CharacterMultiplier {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(" ");
        String str1 = input[0];
        String str2 = input[1];

        int sum = sumMultiplyByChar(str1, str2);
        System.out.println(sum);
    }

    //multiply str1[0] with str2[0] and add to the total sum
    private static int sumMultiplyByChar(String str1, String str2) {
        int len1 = str1.length();
        int len2 = str2.length();
        int sum = 0;

        for (int i = 0; i < Math.min(len1, len2); i++) {
            sum += str1.charAt(i) * str2.charAt(i);
        }
        for (int i = Math.min(len1, len2); i < Math.max(len1, len2); i++) {
            if (len1 > len2) {
                sum += str1.charAt(i);
            } else {
                sum += str2.charAt(i);
            }
        }
        return sum;
    }
}
