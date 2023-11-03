package z_Exam_20200628;

import java.util.*;
import java.util.stream.Collectors;

public class Bombs {
    public static void main(String[] args) {

        //input
        Scanner sc = new Scanner(System.in);
        ArrayDeque<Integer> bombEffectsQueue = new ArrayDeque<>();
        ArrayDeque<Integer> bombCasingStack = new ArrayDeque<>();

        Arrays.stream(sc.nextLine().split(", "))
                .map(Integer::parseInt)
                .forEach(bombEffectsQueue::offer);

        Arrays.stream(sc.nextLine().split(", "))
                .map(Integer::parseInt)
                .forEach(bombCasingStack::push);

        //logic
        int daturaCount = 0;
        int cherryCount = 0;
        int smokeDecoyCount = 0;
        boolean pouchNotFilled = true;

        while (bombEffectsQueue.size() > 0 && bombCasingStack.size() > 0 && pouchNotFilled) {
            int bombCastingCurrent = bombCasingStack.peek();
            int sum = bombEffectsQueue.peek() + bombCasingStack.pop();

            switch (sum) {
                case 40: daturaCount++; bombEffectsQueue.poll(); break;
                case 60: cherryCount++; bombEffectsQueue.poll(); break;
                case 120: smokeDecoyCount++; bombEffectsQueue.poll(); break;
                default:
                    bombCasingStack.push(bombCastingCurrent - 5);
            }

            if (daturaCount >= 3 && cherryCount >= 3 && smokeDecoyCount >= 3) {
                pouchNotFilled = false;
            }
        }

        //output
        //line 1
        if (pouchNotFilled) {
            System.out.println("You don't have enough materials to fill the bomb pouch.");
        } else {
            System.out.println("Bene! You have successfully filled the bomb pouch!");
        }

        //line 2
        System.out.print("Bomb Effects: ");
        if (bombEffectsQueue.isEmpty()) {
            System.out.println("empty");
        } else {
            System.out.println(bombEffectsQueue.toString().replaceAll("[\\[\\]]",""));
        }

        //line 3
        System.out.print("Bomb Casings: ");
        if (bombCasingStack.isEmpty()) {
            System.out.println("empty");
        } else {
            System.out.println(bombCasingStack.toString().replaceAll("[\\[\\]]",""));
        }

        //next lines
        System.out.println("Cherry Bombs: " + cherryCount);
        System.out.println("Datura Bombs: " + daturaCount);
        System.out.println("Smoke Decoy Bombs: " + smokeDecoyCount);

    }
}
