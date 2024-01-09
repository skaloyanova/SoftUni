package i_polymorphism_Lab.animals;

public abstract class Animal {
    private String name;
    private String favouriteFood;

    public Animal(String name, String favouriteFood) {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }

    public String explainSelf() {
        return String.format("I am %s and my favourite food is %s", this.name, this.favouriteFood);
    }

    protected String getName() {
        return name;
    }

    protected String getFavouriteFood() {
        return favouriteFood;
    }
}
