package j_DefiningClasses_Exercises.CatLady;

public class Cat {
    private String catBreed;
    private String catName;
    private double catSpecific;

    public Cat(String catBreed, String catName, double catSpecific) {
        this.catBreed = catBreed;
        this.catName = catName;
        this.catSpecific = catSpecific;
    }

    @Override
    public String toString() {
        return String.format("%s %s %.2f", catBreed, catName, catSpecific);
    }
}
