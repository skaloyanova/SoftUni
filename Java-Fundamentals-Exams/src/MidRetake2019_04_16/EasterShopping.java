package MidRetake2019_04_16;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class EasterShopping {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<String> shops = new ArrayList<>(Arrays.asList(sc.nextLine().split("\\s+")));
        int n = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");

            switch (tokens[0]) {
                case "Include": {
                    String shop = tokens[1];
                    shops.add(shop);
                }
                    break;
                case "Visit": {
                    String firstLast = tokens[1];
                    int number = Integer.parseInt(tokens[2]);
                    if (number > shops.size()) {
                        break;
                    }
                    int index = 0;
                    if ("last".equals(firstLast)) {
                        index = shops.size() - number;
                    }

                    for (int j = 0; j < number; j++) {
                        shops.remove(index);
                    }
                }
                    break;
                case "Prefer":
                    int index1 = Integer.parseInt(tokens[1]);
                    int index2 = Integer.parseInt(tokens[2]);
                    if (isValidIndex(shops, index1) && isValidIndex(shops, index2)) {
                        String shop1 = shops.get(index1);
                        String shop2 = shops.get(index2);
                        shops.set(index1, shop2);
                        shops.set(index2, shop1);
                    }
                    break;
                case "Place": {
                    String shop = tokens[1];
                    int index = Integer.parseInt(tokens[2]);
                    if (isValidIndex(shops, index + 1)) {
                        shops.add(index + 1, shop);
                    }
                }
                    break;
            }
        }

        //output
        System.out.println("Shops left:");
        System.out.println(String.join(" ", shops));
    }

    private static boolean isValidIndex (List<String> shops, int index) {
        return index >= 0 && index < shops.size();
    }
}
