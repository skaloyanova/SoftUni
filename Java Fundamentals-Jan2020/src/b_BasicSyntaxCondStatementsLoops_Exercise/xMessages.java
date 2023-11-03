package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class xMessages {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        String output = "";

        for (int i = 0; i < n; i++) {
            String inputStr = sc.nextLine();

            char digit = inputStr.charAt(0);
            int digitCnt = inputStr.length();

            char letter = 0;

            switch (digit) {
                case '0': letter = ' '; break;
                case '2': letter = 'a'; break;
                case '3': letter = 'd'; break;
                case '4': letter = 'g'; break;
                case '5': letter = 'j'; break;
                case '6': letter = 'm'; break;
                case '7': letter = 'p'; break;
                case '8': letter = 't'; break;
                case '9': letter = 'w'; break;
            }

            output = output + (char) (letter + digitCnt-1);

            }
        System.out.println(output);
    }
}

