package f_encapsulation_Exercises.shoppingSpree;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // read and save in Map people
        Map<String, Person> people = new LinkedHashMap<>();

        //Pesho=11;Gosho=4
        String[] inputPeople = sc.nextLine().split("[;=]");
        for (int i = 0; i < inputPeople.length - 1; i++) {
            people.putIfAbsent(inputPeople[i], new Person(inputPeople[i], Double.parseDouble(inputPeople[++i])));
        }

        // read and save in Map products
        Map<String, Product> products = new LinkedHashMap<>();

        //Bread=10;Milk=2
        String[] inputProducts = sc.nextLine().split("[;=]");
        for (int i = 0; i < inputProducts.length - 1; i++) {
            products.putIfAbsent(inputProducts[i], new Product(inputProducts[i], Double.parseDouble(inputProducts[++i])));
        }

        // read commands for buying products
        String command = sc.nextLine().trim();
        while (!"END".equals(command)) {
            String[] split = command.split("\\s+");

            Person person = people.get(split[0].trim());
            Product product = products.get(split[1].trim());

            if (person != null && product != null) {
                try {
                    person.buyProduct(product);
                    System.out.println(person.getName() + " bought " + product.getName());
                } catch (IllegalStateException ise) {
                    System.out.println(ise.getMessage());
                }
            }

            command = sc.nextLine();
        }

        // print people buy list
        people.values().forEach(System.out::println);
    }
}
