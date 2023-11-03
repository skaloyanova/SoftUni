package FinalRetake2019_12_13;

import java.util.Scanner;

public class WarriorQuest {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String skill = sc.nextLine();

        String command = sc.nextLine();

        while (!"For Azeroth".equals(command)) {
            String[] tokens = command.split("\\s+");

            switch (tokens[0]) {
                case "GladiatorStance":
                    skill = skill.toUpperCase();
                    System.out.println(skill);
                    break;
                case "DefensiveStance":
                    skill = skill.toLowerCase();
                    System.out.println(skill);
                    break;
                case "Dispel":
                    int index = Integer.parseInt(tokens[1]);

                    String letter = tokens[2];
                    StringBuilder sb = new StringBuilder(skill);

                    if (index < 0 || index >= sb.length()) {
                        System.out.println("Dispel too weak.");
                        break;
                    }

                    sb.replace(index, index + 1, letter);
                    skill = sb.toString();
                    System.out.println("Success!");

                    break;
                case "Target":
                    String action = tokens[1];
                    String subString = tokens[2];
                    if (action.equals("Change")) {
                        String newSubString = tokens[3];
                        while (skill.contains(subString)) {
                            skill = skill.replace(subString, newSubString);
                        }
                        System.out.println(skill);
                    } else if (action.equals("Remove")) {
                        skill = skill.replace(subString, "");
                        System.out.println(skill);
                    } else {
                        System.out.println("Command doesn't exist!");
                    }
                    break;
                default:
                    System.out.println("Command doesn't exist!");
                    break;
            }

            command = sc.nextLine();
        }
    }
}
