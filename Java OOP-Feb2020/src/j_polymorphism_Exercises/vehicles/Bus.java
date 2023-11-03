package j_polymorphism_Exercises.vehicles;

public class Bus extends Vehicle {

    public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) {
        super(fuelQuantity, fuelConsumption, tankCapacity);
    }

    @Override
    protected double getFuelConsumptionWithAirConditionOn() {
        return this.getFuelConsumption() + 1.4;
    }
}
