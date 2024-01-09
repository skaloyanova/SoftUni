package h_interfacesAndAbstraction_Exercises.militaryElite;

public class Private extends Soldier {
    private double salary;

    public Private(int id, String firstName, String lastName, double salary) {
        super(id, firstName, lastName);
        this.salary = salary;
    }

    public double getSalary() {
        return salary;
    }

    @Override
    public String toString() {
        return super.toString() + String.format(" Salary: %.2f", this.getSalary());
    }
}
