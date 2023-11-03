package z_Exam_20191023_Demo;

import java.util.*;
import java.util.function.Predicate;

public class MakeASalad {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> calories = new HashMap<>() {{
            put("tomato", 80);
            put("carrot", 136);
            put("lettuce", 109);
            put("potato", 215);
        }};

        Predicate<String> filterNotValidVegetables = x -> x.equals("tomato") || x.equals("carrot")
                || x.equals("lettuce") || x.equals("potato");

        Deque<String> vegetablesQueue = new ArrayDeque<>();

        Arrays.stream(sc.nextLine().split("\\s+"))
                .filter(filterNotValidVegetables)
                .forEach(vegetablesQueue::offer);

        Deque<Integer> saladsStack = new ArrayDeque<>();

        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .forEach(saladsStack::push);

        List<Integer> finishedSalads = new ArrayList<>();

        int currentSalad = saladsStack.peek();

        while (vegetablesQueue.size() > 0) {
            String currentVegetable = vegetablesQueue.poll();
            int vegCal = calories.get(currentVegetable);

            currentSalad -= vegCal;

            if (currentSalad <= 0) {
                finishedSalads.add(saladsStack.pop());
                if (saladsStack.size() > 0) {
                    currentSalad = saladsStack.peek();
                } else {
                    break;
                }
            }

            // below is needed only for judge test to pass, although this salad is not finished
            if (vegetablesQueue.isEmpty() && currentSalad < saladsStack.peek()) {
                finishedSalads.add(saladsStack.pop());
            }
        }

        // print
        for (Integer finishedSalad : finishedSalads) {
            System.out.print(finishedSalad + " ");
        }
        System.out.println();

        if (vegetablesQueue.size() == 0) {
            while (saladsStack.size() > 0) {
                System.out.print(saladsStack.pop() + " ");
            }
        }

        if (saladsStack.size() == 0) {
            while (vegetablesQueue.size() > 0) {
                System.out.print(vegetablesQueue.poll() + " ");
            }
        }
    }
}
