package j_DefiningClasses_Exercises.CatLady;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Cat> cats = new LinkedHashMap<>();

        String input = sc.nextLine();
        while (!"End".equals(input)) {
            String[] tokens = input.split("\\s+");
            String catBreed = tokens[0];
            String catName = tokens[1];
            double catSpecific = Double.parseDouble(tokens[2]);

            cats.put(catName, new Cat(catBreed, catName, catSpecific));

            input = sc.nextLine();
        }

        String catToDisplay = sc.nextLine();
        System.out.println(cats.get(catToDisplay));
    }
}
