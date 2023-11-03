package l_ObjectsAndClasses_Exercise.xRawData;

public class Car {
    private String model;
    private Engine engine;
    private Cargo cargo;
    private Tire tire1;
    private Tire tire2;
    private Tire tire3;
    private Tire tire4;

    public Car(String model, int engineSpeed, int enginePower, int cargoWeight, String cargoType,
               double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age,
               double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age) {
        this.model = model;
        this.engine = new Engine(engineSpeed, enginePower);
        this.cargo = new Cargo(cargoWeight, cargoType);
        this.tire1 = new Tire(tire1Pressure, tire1Age);
        this.tire2 = new Tire(tire2Pressure, tire2Age);
        this.tire3 = new Tire(tire3Pressure, tire3Age);
        this.tire4 = new Tire(tire4Pressure, tire4Age);
    }

    public String getCargoType() {
        return cargo.getType();
    }

    public int getEnginePower() {
        return engine.getPower();
    }

    public double getTire1Pressure() {
        return tire1.getPressure();
    }

    public double getTire2Pressure() {
        return tire2.getPressure();
    }

    public double getTire3Pressure() {
        return tire3.getPressure();
    }

    public double getTire4Pressure() {
        return tire4.getPressure();
    }

    @Override
    public String toString() {
        return this.model;
    }

    public static class Engine {
        private int speed;
        private int power;

        public Engine(int speed, int power) {
            this.speed = speed;
            this.power = power;
        }
        
        public int getPower() {
            return power;
        }
    }

    public static class Cargo {
        private int weight;
        private String type;

        public Cargo(int weight, String type) {
            this.weight = weight;
            this.type = type;
        }

        public String getType() {
            return type;
        }
    }

    public static class Tire {
        private double pressure;
        private int age;

        public Tire(double pressure, int age) {
            this.pressure = pressure;
            this.age = age;
        }

        public double getPressure() {
            return pressure;
        }
    }

}
