package j_DefiningClasses_Exercises.RawData;

public class Engine {
    private String engineSpeed;
    private int enginePower;

    public Engine(String engineSpeed, int enginePower) {
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
    }

    public int getEnginePower() {
        return enginePower;
    }
}
