package h_interfacesAndAbstraction_Exercises.collectionHierarchy;

public class MyListImpl extends Collection implements MyList {

    @Override
    public int add(String item) {
        if (this.getItems().size() < this.getMaxSize()) {
            this.getItems().add(0, item);
        }
        return 0;
    }

    @Override
    public String remove() {
        if (this.getItems().isEmpty()) {
            return null;
        }
        return this.getItems().remove(0);
    }

    @Override
    public int getUsed() {
        return this.getItems().size();
    }
}
