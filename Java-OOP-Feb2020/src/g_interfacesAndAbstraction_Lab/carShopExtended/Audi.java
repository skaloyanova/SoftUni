package g_interfacesAndAbstraction_Lab.carShopExtended;

public class Audi extends CarImpl implements Rentable {
    private Integer minRentDay;
    private Double pricePerDay;


    public Audi(String model, String color, Integer hp, String country, Integer minRentDay, Double pricePerDay) {
        super(model, color, hp, country);
        this.minRentDay = minRentDay;
        this.pricePerDay = pricePerDay;
    }

    @Override
    public Integer getMinRentDay() {
        return minRentDay;
    }

    @Override
    public Double getPricePerDay() {
        return pricePerDay;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("%nMinimum rental period of %d days. Price per day %f",
                this.getMinRentDay(), this.getPricePerDay());
    }
}
