package MidRetake2019_04_16;

import org.w3c.dom.ls.LSOutput;

import java.util.Arrays;
import java.util.Scanner;

public class EasterGifts {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] gifts = sc.nextLine().split("\\s+");

        String input = sc.nextLine();

        while (!"No Money".equals(input)) {
            String[] tokens = input.split("\\s+");

            String command = tokens[0];
            String gift = tokens[1];

            switch (command) {
                case "OutOfStock":
                    for (int i = 0; i < gifts.length; i++) {
                        if (gifts[i].equals(gift)) {
                            gifts[i] = "None";
                        }
                    }
                    break;
                case "Required":
                    int index = Integer.parseInt(tokens[2]);
                    if (index >= 0 && index < gifts.length) {
                        gifts[index] = gift;
                    }
                    break;
                case "JustInCase":
                    gifts[gifts.length - 1] = gift;
                    break;
            }

            input = sc.nextLine();
        }

        //output
        Arrays.stream(gifts).filter(g -> !g.equals("None")).forEach(g -> System.out.print(g + " "));
    }
}
