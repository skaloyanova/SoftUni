package l_ObjectsAndClasses_Exercise.VehicleCatalogue;

public class VehicleCatalogue {
    private String typeOfVehicle;
    private String model;
    private String color;
    private int horsepower;

    public VehicleCatalogue(String typeOfVehicle, String model, String color, int horsepower) {
        this.typeOfVehicle = typeOfVehicle;
        this.model = model;
        this.color = color;
        this.horsepower = horsepower;
    }

    @Override
    public String toString() {

        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Type: %s%n", typeOfVehicle));
        sb.append(String.format("Model: %s%n", model));
        sb.append(String.format("Color: %s%n", color));
        sb.append(String.format("Horsepower: %d", horsepower));

        return sb.toString();
    }

    public String getTypeOfVehicle() {
        return typeOfVehicle;
    }

    public String getModel() {
        return model;
    }

    public String getColor() {
        return color;
    }

    public int getHorsepower() {
        return horsepower;
    }
}
