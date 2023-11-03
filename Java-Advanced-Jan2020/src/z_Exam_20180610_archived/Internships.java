package z_Exam_20180610_archived;

import java.util.ArrayDeque;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class Internships {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int problemsCount = Integer.parseInt(sc.nextLine());
        int candidatesCount = Integer.parseInt(sc.nextLine());

        // stack - push, pop, peek
        ArrayDeque<String> problems = new ArrayDeque<>();
        // queue - offer, poll, peek
        ArrayDeque<String> candidates = new ArrayDeque<>();

        // read and collect problems input
        for (int i = 0; i < problemsCount; i++) {
            problems.push(sc.nextLine());
        }

        // read and collect candidate names input
        for (int i = 0; i < candidatesCount; i++) {
            String name = sc.nextLine();
            Pattern validName = Pattern.compile("([A-Z][a-z]+) ([A-Z][a-z]+)");
            Matcher matcher = validName.matcher(name);

            if (matcher.find()) {
                candidates.offer(name);
            }
        }

        while (problems.size() > 0) {
            String problem = problems.peek();
            String candidate = candidates.peek();

            if (getAsciiSum(problem) < getAsciiSum(candidate)) {   //i.e. problem solved
                problems.pop();
                candidates.offer(candidates.poll());
                System.out.println(String.format("%s solved %s.", candidate, problem));
            } else {        // problem not solved
                problems.addLast(problems.pop());
                candidates.poll();
                System.out.println(String.format("%s failed %s.", candidate, problem));
            }

            if (candidates.size() == 1) {
                System.out.println(candidates.peek() + " gets the job!");
                return;
            }
        }

        if (candidates.size() > 1){
            System.out.println(String.join(", ", candidates));
        }

    }

    private static int getAsciiSum(String text) {
        int sum = 0;
        for (int i = 0; i < text.length(); i++) {
            sum += text.charAt(i);
        }
        return sum;
    }
}
