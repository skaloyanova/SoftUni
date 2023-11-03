package q_RegularExpressions_Lab_Exercise;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class lab_MatchDates {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String dates = sc.nextLine();

        Pattern pattern = Pattern.compile("\\b(?<day>\\d{2})([./\\-])(?<month>[A-Z][a-z]{2})(\\2)(?<year>\\d{4})\\b");
        Matcher matcher = pattern.matcher(dates);

        while (matcher.find()) {
            String day = matcher.group("day");
            String month = matcher.group("month");
            String year = matcher.group("year");
            System.out.println(String.format("Day: %s, Month: %s, Year: %s", day, month, year));
        }
    }
}