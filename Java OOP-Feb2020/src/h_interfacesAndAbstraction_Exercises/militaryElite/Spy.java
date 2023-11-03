package h_interfacesAndAbstraction_Exercises.militaryElite;

public class Spy extends Soldier {
    private String codeNumber;

    public Spy(int id, String firstName, String lastName, String codeNumber) {
        super(id, firstName, lastName);
        this.codeNumber = codeNumber;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("%nCode Number: %s", codeNumber);
    }
}
