package q_RegularExpressions_Lab_Exercise;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Furniture {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String input = sc.nextLine();

        String regex = ">>(?<item>.+)<<(?<price>[\\d.]+)!(?<count>\\d+)";
        Pattern pattern = Pattern.compile(regex);

        StringBuilder output = new StringBuilder();
        output.append("Bought furniture:").append(System.lineSeparator());
        double money = 0;

        while (!"Purchase".equals(input)) {
            Matcher furniture = pattern.matcher(input);

            while (furniture.find()) {
                output.append(furniture.group("item")).append(System.lineSeparator());
                double price = Double.parseDouble(furniture.group("price"));
                int quantity = Integer.parseInt(furniture.group("count"));
                money += price * quantity;
            }
            input = sc.nextLine();
        }
        output.append(String.format("Total money spend: %.2f",money));
        System.out.println(output);
    }
}
