package l_ObjectsAndClasses_Exercise.Articles;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        List<Articles> articles = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] line = sc.nextLine().split(", ");
            Articles article = new Articles(line[0], line[1], line[2]);

            articles.add(article);
        }

        String sortType = sc.nextLine();

        switch (sortType) {
            case "title":
                articles.stream()
                        .sorted((a1, a2) -> a1.getTitle().compareTo(a2.getTitle()))
                        .forEach(a -> System.out.println(a));
                break;
            case "content":
                articles.stream()
                        .sorted((a1, a2) -> a1.getContent().compareTo(a2.getContent()))
                        .forEach(a -> System.out.println(a));
                break;
            case "author":
                articles.stream()
                        .sorted((a1, a2) -> a1.getAuthor().compareTo(a2.getAuthor()))
                        .forEach(a -> System.out.println(a));
                break;
        }
    }
}
