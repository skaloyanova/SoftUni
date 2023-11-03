package Final2020_04_04_gr2;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class FancyBarcodes {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        final String REGEX = "@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
        Pattern pattern = Pattern.compile(REGEX);

        for (int i = 0; i < n; i++) {
            String text = sc.nextLine();

            Matcher matcher = pattern.matcher(text);
            if (!matcher.find()) {
                System.out.println("Invalid barcode");
                continue;
            }
            String barcode = matcher.group();
            StringBuilder digits = new StringBuilder();
            for (int j = 0; j < barcode.length(); j++) {
                if (Character.isDigit(barcode.charAt(j))) {
                    digits.append(barcode.charAt(j));
                }
            }
            String productGroup = digits.length() == 0 ? "00" : digits.toString();
            System.out.println("Product group: " + productGroup);
        }
    }
}
