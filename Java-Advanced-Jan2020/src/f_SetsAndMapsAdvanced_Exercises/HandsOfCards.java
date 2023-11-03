package f_SetsAndMapsAdvanced_Exercises;

import java.util.*;
import java.util.stream.Collectors;

public class HandsOfCards {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Set<String>> players = new LinkedHashMap<>();

        String input = sc.nextLine();
        while (!"JOKER".equals(input)) {
            String[]tokens = input.split(": ");
            String personName = tokens[0];
            Set<String> cards = Arrays.stream(tokens[1].split(", ")).collect(Collectors.toSet());

            players.putIfAbsent(personName, new HashSet<>());
            players.get(personName).addAll(cards);

            input = sc.nextLine();
        }

        Map<String,Integer> cardPower = new HashMap<>() {{
            put("2",2); put("3",3); put("4",4); put("5",5); put("6",6); put("7",7); put("8",8);
            put("9",9); put("10",10); put("J",11); put("Q",12); put("K",13); put("A",14);
        }};

        players.forEach((k,v) -> {
            int cardsValue = 0;
            for (String card : v) {
                String power = "";
                char type = ' ';

                if (card.length() == 3) {
                    power = "" + card.charAt(0) + card.charAt(1);
                    type = card.charAt(2);
                } else {
                    power = "" + card.charAt(0);
                    type = card.charAt(1);
                }

                switch (type) {
                    case 'S': cardsValue += 4 * cardPower.get(power); break;
                    case 'H': cardsValue += 3 * cardPower.get(power); break;
                    case 'D': cardsValue += 2 * cardPower.get(power); break;
                    case 'C': cardsValue += 1 * cardPower.get(power); break;
                }
            }
            System.out.println(k + ": " + cardsValue);
        });
    }
}
