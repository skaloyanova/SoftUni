package h_Methods_Exercise;

import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class ArrayManipulator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] numbers = Arrays.stream(sc.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        while (true) {
            String command = sc.nextLine();
            if (command.equalsIgnoreCase("end")) {
                System.out.println(Arrays.toString(numbers));
                break;
            }
            // transform the command int string array
            String[] cmdArr = command.split(" ");

            switch (cmdArr[0]) {
                case "min":
                case "max":
                    minMaxEvenOdd(numbers, cmdArr[0], cmdArr[1]);
                    break;
                case "first":
                case "last":
                    firstLastCntEvenOdd(numbers, cmdArr[0], Integer.parseInt(cmdArr[1]), cmdArr[2]);
                    break;
                case "exchange":
                    exchange(numbers, Integer.parseInt(cmdArr[1]));
                    break;
            }

        }

    }

    private static void firstLastCntEvenOdd(int[] nums, String firstLast, int count, String evenOdd) {
        if (firstLast.equals("first") && evenOdd.equals("even")) {
            firstCntEven(nums, count);
        } else if (firstLast.equals("first") && evenOdd.equals("odd")) {
            firstCntOdd(nums, count);
        } else if (firstLast.equals("last") && evenOdd.equals("even")) {
            lastCntEven(nums, count);
        } else if (firstLast.equals("last") && evenOdd.equals("odd")) {
            lastCntOdd(nums, count);
        }
    }

    private static void minMaxEvenOdd(int[] nums, String minMax, String evenOdd) {
        if (minMax.equals("min") && evenOdd.equals("even")) {
            minEven(nums);
        } else if (minMax.equals("min") && evenOdd.equals("odd")) {
            minOdd(nums);
        } else if (minMax.equals("max") && evenOdd.equals("even")) {
            maxEven(nums);
        } else if (minMax.equals("max") && evenOdd.equals("odd")) {
            maxOdd(nums);
        }
    }

    private static void exchange(int[] nums, int index) {
        if (!isValidIndex(nums, index)) {
            System.out.println("Invalid index");
            return;
        }

        for (int i = 0; i < index + 1; i++) {
            int temp = nums[0];
            for (int j = 0; j < nums.length - 1; j++) {
                nums[j] = nums[j + 1];
            }
            nums[nums.length - 1] = temp;
        }
    }

    private static void maxEven(int[] nums) {
        int maxEven = Integer.MIN_VALUE;
        int indexEven = -1;

        for (int i = 0; i < nums.length; i++) {
            int current = nums[i];
            if (current % 2 == 0) {
                if (current >= maxEven) {
                    maxEven = current;
                    indexEven = i;
                }
            }
        }
        if (indexEven != -1) {
            System.out.println(indexEven);
        } else {
            System.out.println("No matches");
        }
    }

    private static void maxOdd(int[] nums) {
        int maxOdd = Integer.MIN_VALUE;
        int indexOdd = -1;

        for (int i = 0; i < nums.length; i++) {
            int current = nums[i];
            if (current % 2 != 0) {
                if (current >= maxOdd) {
                    maxOdd = current;
                    indexOdd = i;
                }
            }
        }

        if (indexOdd != -1) {
            System.out.println(indexOdd);
        } else {
            System.out.println("No matches");
        }
    }

    private static void minEven(int[] nums) {
        int minEven = Integer.MAX_VALUE;
        int indexEven = -1;

        for (int i = 0; i < nums.length; i++) {
            int current = nums[i];
            if (current % 2 == 0) {
                if (current <= minEven) {
                    minEven = current;
                    indexEven = i;
                }
            }
        }

        if (indexEven != -1) {
            System.out.println(indexEven);
        } else {
            System.out.println("No matches");
        }
    }

    private static void minOdd(int[] nums) {
        int minOdd = Integer.MAX_VALUE;
        int indexOdd = -1;

        for (int i = 0; i < nums.length; i++) {
            int current = nums[i];
            if (current % 2 != 0) {
                if (current <= minOdd) {
                    minOdd = current;
                    indexOdd = i;
                }
            }
        }

        if (indexOdd != -1) {
            System.out.println(indexOdd);
        } else {
            System.out.println("No matches");
        }
    }

    private static void firstCntEven(int[] nums, int count) {
        if (isNotValidCount(nums, count)) {
            System.out.println("Invalid count");
            return;
        }

        int cnt = 0;
        String evens = "";

        for (int i = 0; i < nums.length; i++) {
            int num = nums[i];
            if (num % 2 == 0) {
                cnt++;
                if (cnt <= count) {
                    evens += nums[i] + " ";
                }
            }
        }

        String[] evenArr = evens.split(" ");

        if (cnt == 0) {
            System.out.println("[]");
        } else {
            System.out.println(Arrays.toString(evenArr));
        }
    }

    private static void firstCntOdd(int[] nums, int count) {
        if (isNotValidCount(nums, count)) {
            System.out.println("Invalid count");
            return;
        }

        int cnt = 0;
        String odds = "";

        for (int i = 0; i < nums.length; i++) {
            int num = nums[i];
            if (num % 2 != 0) {
                cnt++;
                if (cnt <= count) {
                    odds += nums[i] + " ";
                }
            }
        }

        String[] oddArr = odds.split(" ");

        if (cnt == 0) {
            System.out.println("[]");
        } else {
            System.out.println(Arrays.toString(oddArr));
        }
    }

    private static void lastCntEven(int[] nums, int count) {
        if (isNotValidCount(nums, count)) {
            System.out.println("Invalid count");
            return;
        }

        int cnt = 0;
        String evens = "";

        for (int i = nums.length - 1; i >= 0; i--) {
            int num = nums[i];
            if (num % 2 == 0) {
                cnt++;
                if (cnt <= count) {
                    evens += nums[i] + " ";
                }
            }
        }

        String[] evenArr = evens.split(" ");
        Collections.reverse(Arrays.asList(evenArr));

        if (cnt == 0) {
            System.out.println("[]");
        } else {
            System.out.println(Arrays.toString(evenArr));
        }
    }

    private static void lastCntOdd(int[] nums, int count) {
        if (isNotValidCount(nums, count)) {
            System.out.println("Invalid count");
            return;
        }

        int cnt = 0;
        String odds = "";

        for (int i = nums.length - 1; i >= 0; i--) {
            int num = nums[i];
            if (num % 2 != 0) {
                cnt++;
                if (cnt <= count) {
                    odds += nums[i] + " ";
                }
            }
        }

        String[] oddArr = odds.split(" ");
        Collections.reverse(Arrays.asList(oddArr));

        if (cnt == 0) {
            System.out.println("[]");
        } else {
            System.out.println(Arrays.toString(oddArr));
        }
    }

    private static boolean isValidIndex(int[] nums, int index) {
        return (index >= 0) && (index < nums.length);
    }

    private static boolean isNotValidCount(int[] nums, int count) {
        return (count < 1) || (count > nums.length);
    }

}
