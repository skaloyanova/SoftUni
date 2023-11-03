package f_Arrays_Exercise;

import java.util.Scanner;

public class xPascalTriangle {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());    //1 <= n <= 60

        int[] arr = new int[n];
        int[] temp = new int[n];
        arr[0] = 1;
        temp[0] = 1;
        System.out.println(1);

        for (int row = 2; row <= n; row++) {
            StringBuilder print = new StringBuilder();
            print.append("1 ");
            for (int i = 1; i < row; i++) {
                arr[i] = temp[i - 1] + temp[i];
                print.append(arr[i]).append(" ");
            }
            temp = arr.clone();
            System.out.println(print);
        }
    }
}
