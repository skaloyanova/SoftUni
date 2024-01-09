package e_encapsulation_Lab;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    /*
    1. Sort by Name and Age
    */
//    public static void main(String[] args) throws IOException {
//        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
//        int n = Integer.parseInt(reader.readLine());
//
//        List<e_encapsulation_Lab.f_encapsulation_Exercises.shoppingSpree.h_interfacesAndAbstraction_Exercises.multipleImplFoodShortage.Person> people = new ArrayList<>();
//
//        for (int i = 0; i < n; i++) {
//            String input = reader.readLine();
//            people.add(e_encapsulation_Lab.PersonParser.fromString(input));
//        }
//
//        people.sort(new e_encapsulation_Lab.PersonComparator());
//
//        for (e_encapsulation_Lab.f_encapsulation_Exercises.shoppingSpree.h_interfacesAndAbstraction_Exercises.multipleImplFoodShortage.Person person : people) {
//            System.out.println(person.toString());
//        }
//    }

    /*
    2. Salary Increase
    */
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(reader.readLine());

        List<Person> people = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String input = reader.readLine();

            try {
                people.add(PersonParser.fromString(input));
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }

        /*
        double bonus = Double.parseDouble(reader.readLine());

        for (e_encapsulation_Lab.f_encapsulation_Exercises.shoppingSpree.h_interfacesAndAbstraction_Exercises.multipleImplFoodShortage.Person person : people) {
            person.increaseSalary(bonus);
            System.out.println(person.toString());
        }


       !!!! 4. First and Reserve e_encapsulation_Lab.f_encapsulation_Exercises.footballTeamGenerator.Team {add on to 2.} */

        Team team = new Team("Black Eagles");
        for (Person player : people) {
            team.addPlayer(player);
        }

        System.out.println("First team have " + team.getFirstTeam().size() + " players");
        System.out.println("Reserve team have " + team.getReserveTeam().size() + " players");
    }
}
