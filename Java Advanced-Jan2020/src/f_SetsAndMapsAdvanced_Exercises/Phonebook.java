package f_SetsAndMapsAdvanced_Exercises;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Phonebook {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Map<String, String> phoneBook = new HashMap<>();

        String input = sc.nextLine();
        while (!"search".equals(input)) {
            String[]tokens = input.split("-");
            phoneBook.put(tokens[0], tokens[1]);

            input = sc.nextLine();
        }

        input = sc.nextLine();
        while (!"stop".equals(input)) {
            if (phoneBook.containsKey(input)) {
                System.out.println(input + " -> " + phoneBook.get(input));
            } else {
                System.out.println("Contact " + input + " does not exist.");
            }

            input = sc.nextLine();
        }
    }
}
