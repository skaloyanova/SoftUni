package b_StacksAndQueues_Exercises;

import java.util.*;

public class Robotics {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        StringBuilder output = new StringBuilder();

        //read robots line
        String[] robotSplit = sc.nextLine().split("[;]");

        //add robots (name + processTime) in map and names only in array
        Map<String, Integer> robots = new LinkedHashMap<>();
        String[] robotNames = new String[robotSplit.length];

        for (int i = 0; i < robotSplit.length; i++) {
            String[] tokens = robotSplit[i].split("-");
            String robotName = tokens[0];
            int processTime = Integer.parseInt(tokens[1]);
            robots.put(robotName, processTime);
            robotNames[i] = robotName;
        }

        //read start time
        int[] timeSplit = Arrays.stream(sc.nextLine().split(":")).mapToInt(Integer::parseInt).toArray();
        int timeSec = timeSplit[0] * 3600 + timeSplit[1] * 60 + timeSplit[2];

        //read and add in Queue all the products
        ArrayDeque<String> products = addProductsInQueue(sc);

        //create the array with zeroes (all robots are free in the beginning
        int[] currentProcessTimes = new int[robots.size()];

        //process the products
        while (!products.isEmpty()) {
            String currentProduct = products.poll();
            timeSec++;

            //decrease all process times, which are not 0
            decreaseCurrentProcessTimes(currentProcessTimes);

            boolean freeRobotFound = false;

            //checking for free robot
            for (int i = 0; i < currentProcessTimes.length; i++) {
                if (currentProcessTimes[i] == 0) {
                    String freeRobot = robotNames[i];

                    currentProcessTimes[i] = robots.get(freeRobot);

                    String time = getTimeInFormat(timeSec);
                    output.append(String.format("%s - %s [%s]%n", freeRobot, currentProduct, time));
                    freeRobotFound = true;
                    break;
                }
            }

            //add the product at the end of the queue, if there are no free robots
            if (!freeRobotFound) {
                products.offer(currentProduct);
            }
        }

        //print
        System.out.println(output);
    }

    private static void decreaseCurrentProcessTimes(int[] currentProcessTimes) {
        for (int i = 0; i < currentProcessTimes.length; i++) {
            if (currentProcessTimes[i] > 0) {
                currentProcessTimes[i]--;
            }
        }
    }

    private static ArrayDeque<String> addProductsInQueue(Scanner sc) {
        ArrayDeque<String> products = new ArrayDeque<>();
        String product = sc.nextLine();
        while (!"End".equals(product)) {
            products.offer(product);
            product = sc.nextLine();
        }
        return products;
    }

    private static String getTimeInFormat(int time) {
        int hour = (time / 3600) % 24;
        int min = (time / 60) % 60;
        int sec = time % 60;
        return String.format("%02d:%02d:%02d", hour, min, sec);
    }
}
