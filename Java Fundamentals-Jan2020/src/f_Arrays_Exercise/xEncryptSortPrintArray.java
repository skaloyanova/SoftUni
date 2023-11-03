package f_Arrays_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class xEncryptSortPrintArray {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        String allSums = "";

        for (int line = 0; line < n; line++) {
            char[] input = sc.nextLine().toCharArray();
            int length = input.length;

            int sum = 0;

            for (int i = 0; i < length; i++) {
                char currentChar = input[i];
                switch (currentChar) {
                    case 'a':
                    case 'e':
                    case 'o':
                    case 'u':
                    case 'i':
                    case 'A':
                    case 'E':
                    case 'O':
                    case 'U':
                    case 'I':
                        sum += currentChar * length;
                        break;
                    default:
                        sum += currentChar / length;
                        break;
                }
            }
            allSums += sum + " ";
        }
        int[] sumArr = Arrays.stream(allSums.split(" ")).mapToInt(Integer::parseInt).toArray();
        Arrays.sort(sumArr);
        for(int number : sumArr){
            System.out.println(number);
        }
    }
}
