package l_ObjectsAndClasses_Exercise.xCarSalesman;

public class Engine {
    private String model;
    private String power;
    private String displacement;    //opt
    private String efficiency;      //opt

    public Engine(String model, String power, String displacement, String efficiency) {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public String getModel() {
        return model;
    }

    public void setPower(String power) {
        this.power = power;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append(String.format("Power: %s%n", this.power));
        sb.append(String.format("Displacement: %s%n", this.displacement));
        sb.append(String.format("Efficiency: %s%n", this.efficiency));

        return sb.toString();
    }

}
