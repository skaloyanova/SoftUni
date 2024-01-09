package g_interfacesAndAbstraction_Lab.carShopExtended;

public class Seat extends CarImpl implements Sellable {
    private Double price;

    public Seat(String model, String color, Integer hp, String country, Double price) {
        super(model, color, hp, country);
        this.price = price;
    }

    @Override
    public String toString() {
        return super.toString() +  String.format("%n%s sells for %f", this.getModel(), this.getPrice());
    }

    @Override
    public Double getPrice() {
        return this.price;
    }
}
