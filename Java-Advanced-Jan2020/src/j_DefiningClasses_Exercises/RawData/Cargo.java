package j_DefiningClasses_Exercises.RawData;

public class Cargo {
    private String cargoWeight;
    private String cargoType;   // "fragile" or "flamable"

    public Cargo(String cargoWeight, String cargoType) {
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
    }

    public String getCargoType() {
        return cargoType;
    }
}
