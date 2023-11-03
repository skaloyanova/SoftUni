package z_Exam_20200819_Retake.vetClinic;

import java.util.ArrayList;
import java.util.List;

public class Clinic {
    private List<Pet> data;
    private int capacity;

    public Clinic(int capacity) {
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    //adds an entity to the data if there is an empty cell for the pet
    public void add(Pet pet) {
        if (data.size() < capacity) {
            data.add(pet);
        }
    }

    //removes the pet by given name, if such exists, and returns boolean
    public boolean remove(String name) {
        for (Pet pet : data) {
            if (name.equals(pet.getName())) {
                return data.remove(pet);
            }
        }
        return false;
    }

    //returns the pet with the given name and owner or null if no such pet exists
    public Pet getPet(String name, String owner) {
        for (Pet pet : data) {
            if (name.equals(pet.getName()) && owner.equals(pet.getOwner())) {
                return pet;
            }
        }
        return null;
    }

    //returns the oldest Pet
    public Pet getOldestPet() {
        int oldestAge = 0;
        Pet oldestPet = null;

        for (Pet pet : data) {
            if (pet.getAge() > oldestAge) {
                oldestAge = pet.getAge();
                oldestPet = pet;
            }
        }
        return oldestPet;
    }

    //returns the number of pets
    public int getCount() {
        return data.size();
    }

    //stats
    public String getStatistics() {
        StringBuilder builder = new StringBuilder();
        builder.append("The clinic has the following patients:").append(System.lineSeparator());

        for (Pet pet : data) {
            builder.append(pet.getName()).append(" ").append(pet.getOwner()).append(System.lineSeparator());
        }

        return builder.toString();
    }
}
