package MidRetake2019_12_10;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class SchoolLibrary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] booksArr = sc.nextLine().split("&");
        List<String> books = new ArrayList<>(Arrays.asList(booksArr));

        String input = sc.nextLine();

        while (!"Done". equals(input)) {
            String[] tokens = input.split(" \\| ");

            switch (tokens[0]) {
                case "Add Book":{
                    String bookName = tokens[1];
                    if (books.contains(bookName)) {
                        break;
                    }
                    books.add(0, bookName);
                }
                    break;
                case "Take Book":{
                    String bookName = tokens[1];
                    books.remove(bookName);
                }
                    break;
                case "Swap Books":
                    String book1 = tokens[1];
                    String book2 = tokens[2];
                    if (!books.contains(book1) || !books.contains(book2)) {
                        break;
                    }
                    int indexBook1 = books.indexOf(book1);
                    int indexBook2 = books.indexOf(book2);
                    books.set(indexBook1, book2);
                    books.set(indexBook2, book1);
                    break;
                case "Insert Book":{
                    String bookName = tokens[1];
                    books.add(bookName);
                }
                    break;
                case "Check Book":
                    int index = Integer.parseInt(tokens[1]);
                    if (index < 0 || index >= books.size()) {
                        break;
                    }
                    System.out.println(books.get(index));
                    break;
            }

            input = sc.nextLine();
        }

        //Output
        System.out.println(String.join(", ", books));
    }
}
