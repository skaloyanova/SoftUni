package j_polymorphism_Exercises.wildFarm;

public abstract class Food {
    private Integer quantity;

    public Food(Integer quantity) {
        this.quantity = quantity;
    }

    protected Integer getQuantity() {
        return quantity;
    }
}
