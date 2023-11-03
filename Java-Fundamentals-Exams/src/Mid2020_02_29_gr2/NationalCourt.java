package Mid2020_02_29_gr2;

import java.util.Scanner;

public class NationalCourt {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int questionsPerHour1 = Integer.parseInt(sc.nextLine());
        int questionsPerHour2 = Integer.parseInt(sc.nextLine());
        int questionsPerHour3 = Integer.parseInt(sc.nextLine());
        int peopleCnt = Integer.parseInt(sc.nextLine());

        int totalPerHour = questionsPerHour1 + questionsPerHour2 + questionsPerHour3;
        int hoursCnt = 0;
        int counter = 0;

        while (peopleCnt > 0) {

            if (counter == 3) {
                hoursCnt++;
                counter = 0;
            }
            peopleCnt -= totalPerHour;
            counter++;
            hoursCnt++;

        }

        System.out.printf("Time needed: %dh.", hoursCnt);
    }
}
