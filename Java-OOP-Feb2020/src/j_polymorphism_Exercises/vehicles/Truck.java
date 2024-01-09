package j_polymorphism_Exercises.vehicles;

public class Truck extends Vehicle {

    public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) {
        super(fuelQuantity, fuelConsumption, tankCapacity);
    }

    @Override
    protected double getFuelConsumptionWithAirConditionOn() {
        return this.getFuelConsumption() + 1.6;
    }

    @Override
    public void refuel(double liters) {
        super.refuel(0.95 * liters);
    }
}
