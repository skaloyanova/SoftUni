package q_RegularExpressions_Lab_Exercise;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SoftUniBarIncome {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String regex = "%(?<name>[A-Z][a-z]+)%[^|$%.]*?<(?<item>\\w+)>[^|$%.]*?\\|(?<count>\\d+)\\|[^|$%.]*?" +
                "(?<price>[\\d.]+)\\$";

        Pattern pattern = Pattern.compile(regex);
        double money = 0;

        String input = sc.nextLine();
        while (!"end of shift".equals(input)) {
            Matcher matcher = pattern.matcher(input);

            if (matcher.find()) {
                String name = matcher.group("name");
                String product = matcher.group("item");
                int count = Integer.parseInt(matcher.group("count"));
                double price = Double.parseDouble(matcher.group("price"));
                double totalPrice = count * price;
                money += totalPrice;

                System.out.println(String.format("%s: %s - %.2f",name, product, totalPrice));
            }

            input = sc.nextLine();
        }

        System.out.println(String.format("Total income: %.2f", money));
    }
}
