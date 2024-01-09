package h_interfacesAndAbstraction_Exercises.militaryElite;

public class Soldier {
    private int id;
    private String firstName;
    private String lastName;

    public Soldier(int id, String firstName, String lastName) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public int getId() {
        return id;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    @Override
    public String toString() {
        return String.format("Name: %s %s Id: %d",
                this.getFirstName(),
                this.getLastName(),
                this.getId());
    }
}
