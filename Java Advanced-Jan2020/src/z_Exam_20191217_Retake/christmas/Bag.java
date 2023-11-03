package z_Exam_20191217_Retake.christmas;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Bag {
    private String color;
    private int capacity;
    private List<Present> data;

    public Bag(String color, int capacity) {
        this.color = color;
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public String getColor() {
        return this.color;
    }

    public int getCapacity() {
        return this.capacity;
    }

    public int count() {
        return this.data.size();
    }

    public void add(Present present) {
        if (this.data.size() < this.capacity) {
            this.data.add(present);
        }
    }

    public boolean remove(String name) {
        return this.data.removeIf(p -> p.getName().equals(name));
    }

    public Present heaviestPresent() {
        double max = -1;
        Present heaviest = null;
        for (Present present : data) {
            if (present.getWeight() > max) {
                max = present.getWeight();
                heaviest = present;
            }
        }
        return heaviest;
    }

    public Present getPresent(String name) {
        for (Present present : data) {
            if (name.equals(present.getName())) {
                return present;
            }
        }
        return null;
    }

    public String report() {
        return String.format("%s bag contains:%n", this.color)
                + data.stream().map(e -> e.toString()).collect(Collectors.joining(System.lineSeparator()));
    }
}
