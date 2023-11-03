package a_BasicSyntaxCondStatementsLoops_Lab;

import java.util.Scanner;

public class BackIn30Minutes {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int hours = Integer.parseInt(sc.nextLine());
        int minutes = Integer.parseInt(sc.nextLine());

        //modify the addition of minutes
        int additionalMinutes = 30;

        int sumTime = hours * 60 + minutes + additionalMinutes;
        hours = sumTime / 60;
        minutes = sumTime % 60;

        if (hours >= 24) {
            hours -= 24;
        }

        System.out.printf("%d:%02d", hours, minutes);
    }
}
