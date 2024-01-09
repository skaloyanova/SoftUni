package g_interfacesAndAbstraction_Lab.borderControl;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String line = sc.nextLine();

        List<Identifiable> identifiableList = new ArrayList<>();

        while (!"End".equals(line)) {
            //"<name> <age> <id>" for citizens and "<model> <id>" for robots.
            String[] split = line.split("\\s+");

            Identifiable identifiable;

            if (split.length == 3) {
                identifiable = new Citizen(split[0], Integer.parseInt(split[1]), split[2]);
                identifiableList.add(identifiable);
            }

            if (split.length == 2) {
                identifiable = new Robot(split[0], split[1]);
                identifiableList.add(identifiable);
            }

            line = sc.nextLine();
        }

        String fakeIDsDigitsPattern = sc.nextLine();

        identifiableList.stream()
                .filter(e -> e.getId().endsWith(fakeIDsDigitsPattern))
                .forEach(e -> System.out.println(e.getId()));
    }
}
