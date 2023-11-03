package h_interfacesAndAbstraction_Exercises.collectionHierarchy;

import java.util.ArrayList;
import java.util.List;

public abstract class Collection {
    private int maxSize = 100;
    private List<String> items;

    public Collection() {
        this.items = new ArrayList<>(maxSize);
    }

    public int getMaxSize() {
        return maxSize;
    }

    public List<String> getItems() {
        return items;
    }
}
