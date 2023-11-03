package j_DefiningClasses_Exercises.RawData;

import java.util.ArrayList;
import java.util.List;

public class Car {
    private String model;
    private Engine engine;
    private Cargo cargo;
    private List<Tyre> tires;

    public Car(String model,
               String engineSpeed, int enginePower,
               String cargoWeight, String cargoType,
               double tire1Pressure, String tire1Age,
               double tire2Pressure, String tire2Age,
               double tire3Pressure, String tire3Age,
               double tire4Pressure, String tire4Age) {
        this.model = model;
        this.engine = new Engine(engineSpeed, enginePower);
        this.cargo = new Cargo(cargoWeight, cargoType);

        List<Tyre> allTyres = new ArrayList<>();
        allTyres.add(new Tyre(tire1Pressure, tire1Age));
        allTyres.add(new Tyre(tire2Pressure, tire2Age));
        allTyres.add(new Tyre(tire3Pressure, tire3Age));
        allTyres.add(new Tyre(tire4Pressure, tire4Age));
        this.tires = allTyres;
    }

    public String getModel() {
        return model;
    }

    public String getCarCargoType() {
        return cargo.getCargoType();
    }

    public boolean isCarTyrePressureBelow1() {
        for (Tyre tire : tires) {
            if (tire.getTirePressure() < 1) {
                return true;
            }
        }
        return false;
    }

    public boolean isCarPowerAbove250() {
        return engine.getEnginePower() > 250;
    }
}
