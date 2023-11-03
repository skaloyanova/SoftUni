package j_DefiningClasses_Exercises.CarSalesman;

public class Car {
    private String model;
    private Engine engine;
    private String weight;  //opt
    private String color;   //opt

    public Car(String model, Engine engine) {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }

    public Car(String model, Engine engine, String weight, String color) {
        this(model,engine);
        this.weight = weight;
        this.color = color;
    }

    public void setWeight(String weight) {
        this.weight = weight;
    }

    public void setColor(String color) {
        this.color = color;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append(model).append(":").append(System.lineSeparator());
        sb.append(engine).append(System.lineSeparator());
        sb.append("Weight: ").append(weight).append(System.lineSeparator());
        sb.append("Color: ").append(color);
        return sb.toString();
    }
}
