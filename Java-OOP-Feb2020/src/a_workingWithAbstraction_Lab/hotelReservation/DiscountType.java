package a_workingWithAbstraction_Lab.hotelReservation;

public enum DiscountType {
    VIP(0.2),
    SECOND_VISIT(0.1),
    SECONDVISIT(0.1),
    NONE(0.0);

    private double discount;

    DiscountType(double discount) {
        this.discount = discount;
    }

    public double getDiscount() {
        return discount;
    }
}
