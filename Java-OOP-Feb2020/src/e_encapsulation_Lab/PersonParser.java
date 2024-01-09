package e_encapsulation_Lab;

public class PersonParser {

    public static Person fromString(String line) {
        String[] tokens = line.split("\\s+");

        String firstName = tokens[0];
        String lastName = tokens[1];
        int age = Integer.parseInt(tokens[2]);
        double salary;

        if (tokens.length > 3) {
            salary = Double.parseDouble(tokens[3]);
            return new Person(firstName, lastName, age, salary);
        }

        return new Person(firstName, lastName, age);
    }
}
