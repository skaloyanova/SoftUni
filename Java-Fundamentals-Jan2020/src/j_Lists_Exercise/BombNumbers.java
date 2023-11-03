package j_Lists_Exercise;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> numbers = Arrays.stream(sc.nextLine().split("\\s+")).map(Integer::parseInt)
                .collect(Collectors.toList());

        String[] bombInfo = sc.nextLine().split("\\s+");
        int bombNumber = Integer.parseInt(bombInfo[0]);     //9
        int bombPower = Integer.parseInt(bombInfo[1]);      //3
        // 1 4 4 2 8 9 1                                    //remove from index 2 to index 8 (size is 6)
        while (numbers.contains(bombNumber)) {
            int indexBomb = numbers.indexOf(bombNumber);        //5
            int indexToRemove = indexBomb - bombPower;          //2

            int removeCount = bombPower * 2 + 1;

            if (indexToRemove < 0) {
                indexToRemove = 0;
                removeCount = removeCount - Math.abs(indexToRemove);
            }

            while ((removeCount > 0) && (indexToRemove < numbers.size())) {
                numbers.remove(indexToRemove);
                removeCount--;
            }
        }

        int sum = 0;
        for (Integer number : numbers) {
            sum += number;
        }
        System.out.println(sum);
    }
}
