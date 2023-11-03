package j_DefiningClasses_Exercises.RawData;

public class Tyre {
    private double tirePressure;
    private String tireAge;

    public double getTirePressure() {
        return tirePressure;
    }

    public Tyre(double tirePressure, String tireAge) {
        this.tirePressure = tirePressure;
        this.tireAge = tireAge;
    }
}
