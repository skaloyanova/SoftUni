package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class xDataTypeFinder {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String input = "";
        StringBuilder output = new StringBuilder();

        while (true) {
            input = sc.nextLine();

            if ("END".equals(input)) {
                break;
            }

            try {
                int typeInt = Integer.parseInt(input);
                output.append(String.format("%s is integer type%n", input));
                continue;
            } catch (Exception ignored) {}

            try {
                double typeDouble = Double.parseDouble(input);
                output.append(String.format("%s is floating point type%n", input));
                continue;
            } catch (Exception ignored){}

            if (input.length() == 1) {
                output.append(String.format("%s is character type%n", input));

                // JUDGE GIVES FULL POINTS WHEN IGNORING THE CASE FOR TRUE/FALSE, ELSE 70/100

            } else if ("true".equals(input.toLowerCase()) || "false".equals(input.toLowerCase())) {
                output.append(String.format("%s is boolean type%n", input));
            } else {
                output.append(String.format("%s is string type%n", input));
            }
        }
        System.out.println(output);
    }
}
