package z_Exam_20191026;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;

public class DatingApp {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        //stack - push, pop, peek
        ArrayDeque<Integer> males = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .filter(x -> x > 0)
                .forEach(males::push);

        //queue - offer, poll, peek
        ArrayDeque<Integer> females = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .filter(x -> x > 0)
                .forEach(females::offer);

        int matchCnt = 0;

        while (males.size() > 0 && females.size() > 0) {

            if (males.peek() % 25 == 0) {
                males.pop();
                if (males.size() > 0) {
                    males.pop();
                    continue;
                } else {
                    break;
                }
            }

            if (females.peek() % 25 == 0) {
                females.poll();
                if (females.size() > 0) {
                    females.poll();
                    continue;
                } else {
                    break;
                }
            }

            int male = males.pop();
            int female = females.poll();

            if (male == female) {
                matchCnt++;
            } else if (male - 2 > 0) {
                males.push(male - 2);
            }
        }

        // print
        System.out.println("Matches: " + matchCnt);

        if (males.isEmpty()) {
            System.out.println("Males left: none");
        } else {
            System.out.println("Males left: " +
                    males.stream().map(Object::toString).collect(Collectors.joining(", ")));
        }

        if (females.isEmpty()) {
            System.out.println("Females left: none");
        } else {
            System.out.println("Females left: " +
                    females.stream().map(Object::toString).collect(Collectors.joining(", ")));
        }
    }
}
