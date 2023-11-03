package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Scanner;

public class HouseParty {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        ArrayList<String> guestList = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String name = tokens[0];

            switch (tokens[2]) {
                case "going!":
                    if (guestList.contains(name)) {
                        System.out.println(String.format("%s is already in the list!", name));
                    } else {
                        guestList.add(name);
                    }
                    break;
                case "not":
                    if (guestList.contains(name)) {
                        guestList.remove(name);
                    } else {
                        System.out.println(String.format("%s is not in the list!", name));
                    }
                    break;
            }
        }

        for (String name : guestList) {
            System.out.println(name);
        }
    }
}
