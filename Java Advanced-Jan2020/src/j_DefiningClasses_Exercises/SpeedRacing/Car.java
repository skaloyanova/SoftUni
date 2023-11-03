package j_DefiningClasses_Exercises.SpeedRacing;

public class Car {
    private String model;
    private double fuelAmount;
    private double fuelCostPerKm;
    private int distance;   //initial value 0

    public Car(String model, double fuelAmount, double fuelCostPerKm) {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostPerKm = fuelCostPerKm;
        this.distance = 0;
    }

    public void driveCar(int distanceKm) {
        double fuelNeeded = this.fuelCostPerKm * distanceKm;
        if (fuelNeeded <= this.fuelAmount) {
            this.fuelAmount -= fuelNeeded;
            this.distance += distanceKm;
        } else {
            System.out.println("Insufficient fuel for the drive");
        }
    }

    public String toString() {
        return String.format("%s %.2f %d", this.model, this.fuelAmount, this.distance);
    }
}
