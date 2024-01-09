package g_interfacesAndAbstraction_Lab.ferrari;

public class Ferrari implements Car {
    private String driverName;
    private final String MODEL = "488-Spider";

    public Ferrari(String driverName) {
        this.driverName = driverName;
    }

    @Override
    public String brakes() {
        return "Brakes!";
    }

    @Override
    public String gas() {
//        return "Zadu6avam sA!";
        return "brum-brum-brum-brrrrr";
    }

    @Override
    public String toString() {
        return String.format("%s/%s/%s/%s",
                this.MODEL,
                this.brakes(),
                this.gas(),
                this.driverName);
    }
}
