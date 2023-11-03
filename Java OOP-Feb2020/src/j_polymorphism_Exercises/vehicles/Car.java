package j_polymorphism_Exercises.vehicles;

public class Car extends Vehicle {

    public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) {
        super(fuelQuantity, fuelConsumption, tankCapacity);
    }

    @Override
    protected double getFuelConsumptionWithAirConditionOn() {
        return this.getFuelConsumption() + 0.9;
    }
}
