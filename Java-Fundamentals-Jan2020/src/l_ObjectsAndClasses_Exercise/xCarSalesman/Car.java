package l_ObjectsAndClasses_Exercise.xCarSalesman;

public class Car {
    private String model;
    private Engine engine;
    private String weight;  //opt
    private String color;   //opt

    public Car(String model, Engine engine, String weight, String color) {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%s:%n", this.model));
        sb.append(String.format("%s:%n", this.engine.getModel()));
        sb.append(engine.toString());
        sb.append(String.format("Weight: %s%n",this.weight));
        sb.append(String.format("Color: %s", this.color));

        return sb.toString();
    }

}

