package z_Exam_20200222;

import java.util.*;

public class Lootbox {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // queue - offer, poll
        ArrayDeque<Integer> box1 = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+")).map(Integer::parseInt).forEach(box1::offer);

        // stack - push, pop
        ArrayDeque<Integer> box2 = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+")).map(Integer::parseInt).forEach(box2::push);

        List<Integer> claimedItems = new ArrayList<>();

        while (box1.size() > 0 && box2.size() > 0) {
            int loot = box1.peek() + box2.peek();

            if (loot % 2 == 0) {
                claimedItems.add(loot);
                box1.poll();
                box2.pop();
            } else {
                box1.offer(box2.pop());
            }
        }

        if (box1.isEmpty()) {
            System.out.println("First lootbox is empty");
        } else {
            System.out.println("Second lootbox is empty");
        }

        int sum = claimedItems.stream().mapToInt(e -> e).sum();

        if (sum >= 100) {
            System.out.println("Your loot was epic! Value: " + sum);
        } else {
            System.out.println("Your loot was poor... Value: " + sum);
        }

    }
}
