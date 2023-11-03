package j_DefiningClasses_Exercises.Google;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String,Person> people = new HashMap<>();

        String input = sc.nextLine();
        while (!"End".equals(input)) {
            //Input types:
            //"<Name> company <companyName> <department> <salary>"
            //"<Name> pokemon <pokemonName> <pokemonType>"
            //"<Name> parents <parentName> <parentBirthday>"
            //"<Name> children <childName> <childBirthday>"
            //"<Name> car <carModel> <carSpeed>"
            String[] tokens = input.split("\\s+");
            String personName = tokens[0];
            String dataType = tokens[1];

            people.putIfAbsent(personName, new Person(personName));

            if (tokens.length == 5) {
                people.get(personName).addCompany(tokens[2], tokens[3], Double.parseDouble(tokens[4]));
            } else {
                people.get(personName).addData(dataType, tokens[2], tokens[3]);
            }

            input = sc.nextLine();
        }
        //output
        String personToDisplay = sc.nextLine();
        System.out.println(people.get(personToDisplay));
    }
}
