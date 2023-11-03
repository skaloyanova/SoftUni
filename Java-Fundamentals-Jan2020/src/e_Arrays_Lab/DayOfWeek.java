package e_Arrays_Lab;

import java.util.Scanner;

public class DayOfWeek {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int dayNumber = Integer.parseInt(sc.nextLine());    //1..7

        String[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

        int index = dayNumber - 1;

        if (index >= 0 && index < days.length) {
            System.out.println(days[index]);
        } else {
            System.out.println("Invalid day!");
        }
    }
}
