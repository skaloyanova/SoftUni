package q_RegularExpressions_Lab_Exercise;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ExtractEmails {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        String emailRegex = "\\b(?<user>[A-Za-z\\d][\\w.-]*[A-Za-z\\d])" +
                "@(?<word1>[A-Za-z][A-Za-z\\-]*[A-Za-z])\\.(?<word2>[A-Za-z][A-Za-z\\-]*[A-Za-z])" +
                "(\\.(?<word3>[A-Za-z][A-Za-z\\-]*[A-Za-z]))*";
        Pattern pattern = Pattern.compile(emailRegex);
        Matcher matcher = pattern.matcher(text);

        while (matcher.find()) {
            System.out.println(matcher.group());
        }
    }
}
