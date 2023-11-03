package z_Exam_20190813_Retake_noJudge.aquariumAdventure;

import java.util.*;
import java.util.stream.Collectors;

public class Aquarium {
    private String name;
    private int capacity;
    private int size;
    private Map<String, Fish> fishInPool;

    public Aquarium(String name, int capacity, int size) {
        this.name = name;
        this.capacity = capacity;
        this.size = size;
        fishInPool = new LinkedHashMap<>();
    }



    // adds the entity if there isn't a fish with the same name and if there is enough space for it.
    public void add(Fish fish) {
        if (fishInPool.size() < this.capacity) {
            fishInPool.putIfAbsent(fish.getName(), fish);
        }
    }

    // removes a fish from the pool with the given name, if such exists and returns boolean if the deletion is successful.
    public boolean remove(String name) {
        if (fishInPool.containsKey(name)) {
            fishInPool.remove(name);
            return true;
        }
        return false;
    }

    // returns a fish with the given name. If it doesn't exist, return null.
    public Fish findFish(String name) {
        return fishInPool.get(name);
    }

    // returns information about the aquarium and the fish inside it in the following format
    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Aquarium: %s ^ Size: %d", this.name, this.size)).append(System.lineSeparator());
        sb.append(fishInPool.values().stream().map(Fish::toString).collect(Collectors.joining(System.lineSeparator())));

        return sb.toString();
    }
}
