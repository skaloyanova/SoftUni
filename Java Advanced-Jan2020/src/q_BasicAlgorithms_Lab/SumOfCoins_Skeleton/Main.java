package q_BasicAlgorithms_Lab.SumOfCoins_Skeleton;

import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);

        String[] elements = in.nextLine().substring(7).split(", ");
        int[] coins = new int[elements.length];
        for (int i = 0; i < coins.length; i++) {
            coins[i] = Integer.parseInt(elements[i]);
        }

        int targetSum = Integer.parseInt(in.nextLine().substring(5));


        Map<Integer, Integer> usedCoins = chooseCoins(coins, targetSum);

        if (usedCoins == null) {
            System.out.println("Error");
            return;
        }

        for (Map.Entry<Integer, Integer> usedCoin : usedCoins.entrySet()) {
            System.out.println(usedCoin.getKey() + " -> " + usedCoin.getValue());
        }
    }

    public static Map<Integer, Integer> chooseCoins(int[] coins, int targetSum) {
        Map<Integer, Integer> coinCount = new LinkedHashMap<>();
        Arrays.sort(coins);

        int index = coins.length - 1;

        while (index >= 0 && targetSum > 0) {
            int maxCoin = coins[index];

            if (targetSum - maxCoin >= 0) {
                int maxCoinCnt = targetSum / maxCoin;
                targetSum = targetSum % maxCoin;
                coinCount.put(maxCoin, maxCoinCnt);
            }
            index--;
        }

        if (index < 0 && targetSum != 0) {
            return null;
        }

        return coinCount;
    }
}