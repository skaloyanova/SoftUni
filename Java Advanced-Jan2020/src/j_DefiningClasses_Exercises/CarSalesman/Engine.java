package j_DefiningClasses_Exercises.CarSalesman;

public class Engine {
    private String model;
    private int power;
    private String displacement;    //opt
    private String efficiency;      //opt

    public Engine(String model, int power) {
        this.model = model;
        this.power = power;
        this.displacement = "n/a";
        this.efficiency = "n/a";
    }

    public Engine(String model, int power, String displacement, String efficiency) {
        this(model, power);
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public void setDisplacement(String displacement) {
        this.displacement = displacement;
    }

    public void setEfficiency(String efficiency) {
        this.efficiency = efficiency;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append(model).append(":").append(System.lineSeparator());
        sb.append("Power: ").append(power).append(System.lineSeparator());
        sb.append("Displacement: ").append(displacement).append(System.lineSeparator());
        sb.append("Efficiency: ").append(efficiency);
        return sb.toString();
    }
}
