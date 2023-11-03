package MidRetake2020_04_07;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class ShootForTheWin {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] targetArr = sc.nextLine().split("\\s+");
        List<Integer> targets = Arrays.stream(targetArr).map(Integer::parseInt).collect(Collectors.toList());

        int targetCnt = 0;
        String input = sc.nextLine();

        while (!"End".equals(input)) {
            int targetIndex = Integer.parseInt(input);

            if (targetIndex < 0 || targetIndex >= targets.size()) {
                input = sc.nextLine();
                continue;
            }
            int targetValue = targets.get(targetIndex);
            targets.set(targetIndex, -1);
            targetCnt++;

            for (int i = 0; i < targets.size(); i++) {
                Integer target = targets.get(i);
                if (target == -1) {
                    continue;
                }
                int newValue = target > targetValue ? target - targetValue : target + targetValue;
                targets.set(i, newValue);
            }

            input = sc.nextLine();
        }
        //output
        System.out.printf("Shot targets: %d -> ", targetCnt);

        for (Integer target : targets) {
            System.out.print(target + " ");
        }
    }
}
