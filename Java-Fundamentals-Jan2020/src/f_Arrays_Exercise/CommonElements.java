package f_Arrays_Exercise;

import java.util.Scanner;

public class CommonElements {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] text1 = sc.nextLine().split(" ");
        String[] text2 = sc.nextLine().split(" ");

//        for (int i = 0; i < text2.length; i++) {
//            for (int j = 0; j < text1.length; j++) {
//                if (text2[i].equals(text1[j])) {
//                    common.append(text2[i]).append(" ");
//                }
//            }
//        }

        for (String s2 : text2) {
            for (String s1 : text1) {
                if (s2.equals(s1)) {
                    System.out.print(s2 + " ");
                    break;
                }
            }
        }
    }
}
