package a_workingWithAbstraction_Lab.hotelReservation;

public class PriceCalculator {
    private double pricePerDay;
    private int numberOfDays;
    private Season season;
    private DiscountType discountType;

    public PriceCalculator(double pricePerDay, int numberOfDays, Season season, DiscountType discountType) {
        this.pricePerDay = pricePerDay;
        this.numberOfDays = numberOfDays;
        this.season = season;
        this.discountType = discountType;
    }

    public double calculatePrice() {
        double price = pricePerDay * season.getPriceMultiplier() * numberOfDays;
        double discount = price * discountType.getDiscount();

        return price - discount;
    }
}
