package z_Exam_20191026.rabbits;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Cage {
    private String name;
    private int capacity;
    private List<Rabbit> data;

    public Cage(String name, int capacity) {
        this.name = name;
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public int getCapacity() {
        return capacity;
    }

    public void add(Rabbit rabbit) {
        if (data.size() < this.capacity) {
            this.data.add(rabbit);
        }
    }

    public boolean removeRabbit(String name) {
        return this.data.removeIf(rabbit -> rabbit.getName().equals(name));
    }

    public void removeSpecies(String species) {
        this.data.removeIf(rabbit -> rabbit.getSpecies().equals(species));
    }

    public Rabbit sellRabbit(String name) {
        for (Rabbit rabbit : this.data) {
            if (rabbit.getName().equals(name)) {
                rabbit.setAvailable(false);
                return rabbit;
            }
        }
        return null;
    }

    public List<Rabbit> sellRabbitBySpecies(String species) {
        List<Rabbit> sold = new ArrayList<>();
        for (Rabbit rabbit : data) {
            if (rabbit.getSpecies().equals(species)) {
                rabbit.setAvailable(false);
                sold.add(rabbit);
            }
        }
        return sold;
    }

    public int count() {
        return this.data.size();
    }

    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Rabbits available at %s:%n", this.name));
        sb.append(this.data.stream()
                .filter(Rabbit::isAvailable)
                .map(Rabbit::toString)
                .collect(Collectors.joining(System.lineSeparator())));

        return sb.toString();
    }
}
