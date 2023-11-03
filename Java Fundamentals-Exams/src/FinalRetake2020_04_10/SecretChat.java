package FinalRetake2020_04_10;

import java.util.Scanner;

public class SecretChat {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        StringBuilder text = new StringBuilder(sc.nextLine());

        String input = sc.nextLine();

        while (!"Reveal".equals(input)) {
            String[] tokens = input.split(":\\|:");

            switch (tokens[0]) {
                case "InsertSpace":
                    int index = Integer.parseInt(tokens[1]);
                    text.insert(index, " ");
                    System.out.println(text);
                    break;
                case "Reverse":
                    String subString = tokens[1];
                    StringBuilder sub = new StringBuilder(subString);
                    int indexSub = text.indexOf(subString);
                    if (indexSub == -1) {
                        System.out.println("error");
                    } else {
                        text.delete(indexSub, indexSub + subString.length());
                        text.append(sub.reverse());
                        System.out.println(text);
                    }
                    break;
                case "ChangeAll":
                    String stringToReplace = tokens[1];
                    String replacement = tokens[2];
                    String tmp = text.toString();
                    tmp = tmp.replaceAll(stringToReplace, replacement);
                    text.setLength(0);
                    text.append(tmp);
                    System.out.println(text);
                    break;
            }
            input = sc.nextLine();
        }
        System.out.println("You have a new text message: " + text);
    }
}
