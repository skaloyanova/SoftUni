package g_Methods_Lab;

import java.util.Scanner;

public class GreaterOfTwoValues {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String type = sc.nextLine().toLowerCase();
        String arg1 = sc.nextLine();
        String arg2 = sc.nextLine();

        switch (type) {
            case "int":
                System.out.println(getMax(Integer.parseInt(arg1), Integer.parseInt(arg2)));
                break;
            case "char":
                System.out.println(getMax(arg1.charAt(0), arg2.charAt(0)));
                break;
            case "string":
                System.out.println(getMax(arg1, arg2));
                break;
        }

    }

    private static int getMax(int input1, int input2) {
        int greater = (input1 > input2) ? input1 : input2;
        return greater;
    }

    private static char getMax(char input1, char input2) {
        char greater = (input1 > input2) ? input1 : input2;
        return greater;
    }

    private static String getMax(String input1, String input2) {
        String greater = input1.compareTo(input2) >= 0 ? input1 : input2;
        return greater;
    }


}

