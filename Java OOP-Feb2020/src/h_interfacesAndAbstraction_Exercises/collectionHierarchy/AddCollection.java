package h_interfacesAndAbstraction_Exercises.collectionHierarchy;

public class AddCollection extends Collection implements Addable {

    @Override
    public int add(String item) {
        if (this.getItems().size() < this.getMaxSize()) {
            this.getItems().add(item);
        }
        return this.getItems().size() - 1;
    }
}
