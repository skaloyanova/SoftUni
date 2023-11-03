package FinalRetake2019_12_13;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class BossRush {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        String regex = "\\|(?<boss>[A-Z]{4,})\\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";
        Pattern pattern = Pattern.compile(regex);

        for (int i = 0; i < n; i++) {
            String input = sc.nextLine();

            Matcher matcher = pattern.matcher(input);

            if (!matcher.find()) {
                System.out.println("Access denied!");
            } else {
                String bossName = matcher.group("boss");
                String bossTitle = matcher.group("title");
                System.out.println(bossName + ", The " + bossTitle);
                System.out.println(">> Strength: " + bossName.length());
                System.out.println(">> Armour: " + bossTitle.length());
            }
        }
    }
}
