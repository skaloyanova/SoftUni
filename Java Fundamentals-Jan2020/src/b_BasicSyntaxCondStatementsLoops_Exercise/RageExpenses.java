package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class RageExpenses {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int lostGamesCnt = Integer.parseInt(sc.nextLine());
        double headsetPrice = Double.parseDouble(sc.nextLine());
        double mousePrice = Double.parseDouble(sc.nextLine());
        double keyboardPrice = Double.parseDouble(sc.nextLine());
        double displayPrice = Double.parseDouble(sc.nextLine());

        int brokenHeadsetCnt = lostGamesCnt / 2;
        int brokenMouseCnt = lostGamesCnt / 3;
        int brokenKeyboardCnt = lostGamesCnt / 6;
        int brokenDisplayCnt = lostGamesCnt / 12;

        double expenses = headsetPrice * brokenHeadsetCnt + mousePrice * brokenMouseCnt
                + keyboardPrice * brokenKeyboardCnt + displayPrice * brokenDisplayCnt;
        System.out.println(String.format("Rage expenses: %.2f lv.", expenses));
    }
}
