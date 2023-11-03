package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class xBalancedBrackets {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        int openingCnt = 0;
        int closingCnt = 0;

        boolean isBalanced = true;

        for (int i = 0; i < n; i++) {
            String text = sc.nextLine();

            if (text.equals("(")) {
                openingCnt++;

                if (openingCnt - closingCnt >= 2) {
                    isBalanced = false;
                    break;
                }

            } else if (text.equals(")")) {
                closingCnt++;

                if (closingCnt > openingCnt) {
                    isBalanced = false;
                    break;
                }
            }
        }

        if (openingCnt != closingCnt) {
            isBalanced = false;
        }

        if (isBalanced){
            System.out.println("BALANCED");
        } else{
            System.out.println("UNBALANCED");
        }
    }
}

