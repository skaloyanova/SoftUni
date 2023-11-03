package z_Exam_20200819_Retake;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class FlowerWreaths {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        //stack - push, pop, peek
        Deque<Integer> lilies = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split(", "))
                .map(Integer::parseInt)
                .forEach(lilies::push);

        //queue - offer, poll, peek
        Deque<Integer> roses = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split(", "))
                .map(Integer::parseInt)
                .forEach(roses::offer);

        int wreathCount = 0;
        int storedFlowers = 0;

        while (!lilies.isEmpty() && !roses.isEmpty()) {
            int sum = lilies.peek() + roses.peek();

            if (sum == 15) {
                wreathCount++;
                lilies.pop();
                roses.poll();
            } else if (sum > 15) {
                lilies.push(lilies.pop() - 2);
            } else {
                lilies.pop();
                roses.poll();
                storedFlowers += sum;
            }
        }

        if (storedFlowers > 0) {
            wreathCount += storedFlowers / 15;
        }

        //output
        if (wreathCount >= 5) {
            System.out.printf("You made it, you are going to the competition with %d wreaths!%n", wreathCount);
        } else {
            System.out.printf("You didn't make it, you need %d wreaths more!%n", 5 - wreathCount);
        }
    }
}
