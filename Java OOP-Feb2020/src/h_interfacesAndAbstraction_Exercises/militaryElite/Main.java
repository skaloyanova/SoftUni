package h_interfacesAndAbstraction_Exercises.militaryElite;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<Integer, Private> privates = new LinkedHashMap<>();

        String soldierInfo = sc.nextLine();

        while (!"End".equals(soldierInfo)) {

            String[] split = soldierInfo.split("\\s+");

            String type = split[0];
            int id = Integer.parseInt(split[1]);
            String firstName = split[2];
            String lastName = split[3];

            switch (type) {
                case "h_interfacesAndAbstraction_Exercises.militaryElite.Private":
                    Private priv = new Private(id, firstName, lastName, Double.parseDouble(split[4]));
                    privates.putIfAbsent(id, priv);
                    System.out.println(priv);
                    break;
                case "LeutenantGeneral":
                    LieutenantGeneral lieutenantGeneral;
                    try {
                        lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, Double.parseDouble(split[4]));
                    } catch (IllegalArgumentException e) {
                        break;
                    }
                    for (int i = 5; i < split.length; i++) {
                        int privateId = Integer.parseInt(split[i]);
                        Private privE = privates.get(privateId);
                        if (privE != null) {
                            lieutenantGeneral.addPrivate(privE);
                        }
                    }
                    System.out.println(lieutenantGeneral);
                    break;
                case "h_interfacesAndAbstraction_Exercises.militaryElite.Engineer":
                    Engineer engineer;
                    try {
                        engineer = new Engineer(id, firstName, lastName, Double.parseDouble(split[4]), split[5]);
                    }catch (IllegalArgumentException e) {
                        break;
                    }
                    for (int i = 6; i < split.length - 1; i++) {
                        engineer.addRepair(new Repair(split[i], Integer.parseInt(split[++i])));
                    }
                    System.out.println(engineer);
                    break;
                case "h_interfacesAndAbstraction_Exercises.militaryElite.Commando":
                    Commando commando;
                    try {
                        commando = new Commando(id, firstName, lastName, Double.parseDouble(split[4]), split[5]);
                    } catch (IllegalArgumentException e) {
                        break;
                    }
                    for (int i = 6; i < split.length - 1; i++) {
                        try {
                            commando.addMission(new Mission(split[i], split[++i]));
                        } catch (IllegalArgumentException ignored) { }
                    }
                    System.out.println(commando);
                    break;
                case "h_interfacesAndAbstraction_Exercises.militaryElite.Spy":
                    Spy spy = new Spy(id, firstName, lastName, split[4]);
                    System.out.println(spy);
                    break;
            }

            soldierInfo = sc.nextLine();
        }
    }
}
