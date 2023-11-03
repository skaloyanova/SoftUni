package l_ObjectsAndClasses_Exercise;

import java.util.Random;
import java.util.Scanner;

public class AdvertisementMessage {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Random random = new Random();

        String[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product."};

        String[] events = {"Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"};

        String[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

        String[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

        int messages = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < messages; i++) {
            String phrase = phrases[random.nextInt(phrases.length)];
            String event = events[random.nextInt(events.length)];
            String author = authors[random.nextInt(authors.length)];
            String city = cities[random.nextInt(cities.length)];

            System.out.println(String.format("%s %s %s - %s", phrase, event, author, city));
        }
    }

}
