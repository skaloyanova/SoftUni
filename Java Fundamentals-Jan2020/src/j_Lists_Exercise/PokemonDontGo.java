package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Scanner;

public class PokemonDontGo {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] inputArr = sc.nextLine().split("\\s+");
        ArrayList<Integer> data = new ArrayList<>();

        for (String element : inputArr) {
            data.add(Integer.parseInt(element));
        }

        int sum = 0;
        while (true) {
            int index = Integer.parseInt(sc.nextLine());
            int removedElement;

            if (index < 0) {
                index = 0;
                removedElement = data.remove(index);
                sum += removedElement;
                data.add(0, data.get(data.size() - 1));
            } else if (index > data.size() - 1) {
                index = data.size() - 1;
                removedElement = data.remove(index);
                sum += removedElement;
                data.add(data.get(0));
            } else {
                removedElement = data.remove(index);
                sum += removedElement;
            }
            for (int i = 0; i < data.size(); i++) {
                int current = data.get(i);
                if (current <= removedElement) {
                    data.set(i, (current + removedElement));
                } else {
                    data.set(i, (current - removedElement));
                }
            }
            if (data.size() == 0) {
                break;
            }
        }
        System.out.println(sum);
    }
}
