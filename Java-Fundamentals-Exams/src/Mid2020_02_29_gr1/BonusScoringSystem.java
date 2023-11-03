package Mid2020_02_29_gr1;

import java.util.Scanner;

public class BonusScoringSystem {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int studentsCnt = Integer.parseInt(sc.nextLine());
        int lecturesCnt = Integer.parseInt(sc.nextLine());
        int bonus = Integer.parseInt(sc.nextLine());

        double maxBonus = 0;
        int maxAttendance = 0;
        for (int i = 0; i < studentsCnt; i++) {
            int attendance = Integer.parseInt(sc.nextLine());

            double bonusStudent = attendance * 1.0 / lecturesCnt * (5 + bonus);

            if (bonusStudent >= maxBonus) {
                maxBonus = bonusStudent;
                maxAttendance = attendance;
            }
        }

        System.out.printf("Max Bonus: %.0f.%n", Math.ceil(maxBonus));
        System.out.printf("The student has attended %d lectures.", maxAttendance);

    }
}
