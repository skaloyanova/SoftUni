package f_Arrays_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class xLongestIncreasingSubsequence {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] num = Arrays.stream(sc.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int length = num.length;
        int[] len = new int[length];
        int[] prev = new int[length];
        prev[0] = -1;

        int maxLength = 0;
        int lastIndex = -1;

        for (int p = 0; p < length; p++) {
            len[p] = 1;
            for (int left = 0; left < p; left++) {
                if (num[left] < num[p] && len[left] + 1 > len[p]) {
                    len[p] = 1 + len[left];
                    prev[p] = left;
                }
            }
            if (len[p] > maxLength) {
                maxLength = len[p];
                lastIndex = p;
            }
        }

        int[] lis = new int[maxLength];
        for (int i = lis.length - 1; i >= 0; i--) {
            lis[i] = num[lastIndex];
            lastIndex = prev[lastIndex];
        }

        for (int number : lis) {
            System.out.print(number + " ");
        }
    }
}
