package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class PadawanEquipment {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        double money = Double.parseDouble(sc.nextLine());       //0.00…1,000.00
        int students = Integer.parseInt(sc.nextLine());         //0…100
        double saberPrice = Double.parseDouble(sc.nextLine());  //0.00…100.00
        double robePrice = Double.parseDouble(sc.nextLine());   //0.00…100.00
        double beltPrice = Double.parseDouble(sc.nextLine());   //0.00…100.00

        int beltFree = students / 6;

        double saberCost = Math.ceil(1.1 * students) * saberPrice;
        double robeCost = students * robePrice;
        double beltCost = (students - beltFree) * beltPrice;

        double totalCost = saberCost + robeCost + beltCost;

        if (money >= totalCost) {
            System.out.println(String.format("The money is enough - it would cost %.2flv.", totalCost));
        } else {
            System.out.println(String.format("Ivan Cho will need %.2flv more.", (totalCost - money)));
        }
    }
}
