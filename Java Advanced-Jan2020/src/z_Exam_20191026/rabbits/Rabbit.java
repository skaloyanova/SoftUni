package z_Exam_20191026.rabbits;

public class Rabbit {
    private String name;
    private String species;
    private boolean available;

    public Rabbit(String name, String species) {
        this.name = name;
        this.species = species;
        this.available = true;
    }

    public String getName() {
        return name;
    }

    public String getSpecies() {
        return species;
    }

    public void setAvailable(boolean available) {
        this.available = available;
    }

    public boolean isAvailable() {
        return this.available;
    }

    @Override
    public String toString() {
        return String.format("Rabbit (%s): %s", this.species, this.name);
    }

}
