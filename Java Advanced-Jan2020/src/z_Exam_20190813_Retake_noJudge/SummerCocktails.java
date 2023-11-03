package z_Exam_20190813_Retake_noJudge;

import java.util.*;

public class SummerCocktails {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        //queue -> offer, poll, peek
        ArrayDeque<Integer> ingredientsQueue = new ArrayDeque<>();
        //stack -> push, pop, peek
        ArrayDeque<Integer> freshnessStack = new ArrayDeque<>();

        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .filter(x -> x != 0)
                .forEach(ingredientsQueue::offer);

        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .filter(x -> x != 0)
                .forEach(freshnessStack::push);

        Map<String, Integer> cocktailsMade = new TreeMap<>();

        while (ingredientsQueue.size() > 0 && freshnessStack.size() > 0) {

            int currentIngredient = ingredientsQueue.poll();
            int currentFreshness = freshnessStack.pop();

            int mix = currentIngredient * currentFreshness;

            String cocktail = getCocktailName(mix);

            if (cocktail != null) {
                cocktailsMade.putIfAbsent(cocktail, 0);
                cocktailsMade.put(cocktail, cocktailsMade.get(cocktail) + 1);
            } else {
                currentIngredient += 5;
                ingredientsQueue.offer(currentIngredient);
            }
        }

        //print
        if (cocktailsMade.size() == 4) {
            System.out.println("It's party time! The cocktails are ready!");
        } else {
            System.out.println("What a pity! You didn't manage to prepare all cocktails.");
        }

        if (ingredientsQueue.size() > 0) {
            System.out.println("Ingredients left: " + ingredientsQueue.stream().mapToInt(Integer::intValue).sum());
        }

        cocktailsMade.forEach((k,v) -> System.out.println(" # " + k + " --> " + v));

    }

    private static String getCocktailName(int fresh) {
        switch (fresh) {
            case 150: return "Mimosa";
            case 250: return "Daiquiri";
            case 300: return "Sunshine";
            case 400: return "Mojito";
            default: return null;
        }
    }
}
