package j_polymorphism_Exercises.vehicles;

import java.text.DecimalFormat;

public abstract class Vehicle {
    private double fuelQuantity;
    private double fuelConsumption;     //liters per km
    private int tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity) {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumption = fuelConsumption;
        this.tankCapacity = tankCapacity;
    }

    public double getFuelQuantity() {
        return fuelQuantity;
    }

    public double getFuelConsumption() {
        return fuelConsumption;
    }

    private void reduceFuelQuantityWith(double fuelToRemove) {
        this.fuelQuantity -= fuelToRemove;
    }

    protected abstract double getFuelConsumptionWithAirConditionOn();

    public String drive(double distance) {
        return driveWithOrWithoutAirCondition(distance, true);
    }

    public String driveEmpty(double distance) {
        return this.driveWithOrWithoutAirCondition(distance, false);
    }

    private String driveWithOrWithoutAirCondition(double distance, boolean withAirCondition) {
        double fuelNeeded = distance * this.getFuelConsumption();

        if (withAirCondition) {
            fuelNeeded = distance * getFuelConsumptionWithAirConditionOn();
        }

        if (fuelNeeded > fuelQuantity) {
            return String.format("%s needs refueling", this.getClass().getSimpleName());
        }

        this.reduceFuelQuantityWith(fuelNeeded);
        return String.format("%s travelled %s km",
                this.getClass().getSimpleName(),
                new DecimalFormat("#.##").format(distance));
    }

    public void refuel(double liters) {
        if (liters <= 0) {
            throw new IllegalArgumentException("Fuel must be a positive number");
        }
        if (fuelQuantity + liters > tankCapacity) {
            throw new IllegalArgumentException("Cannot fit fuel in tank");
        }

        fuelQuantity += liters;
    }

    public String showRemainingFuel() {
        return String.format("%s: %.2f", this.getClass().getSimpleName(), this.getFuelQuantity());
    }
}
