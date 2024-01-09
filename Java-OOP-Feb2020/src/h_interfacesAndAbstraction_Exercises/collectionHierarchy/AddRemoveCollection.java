package h_interfacesAndAbstraction_Exercises.collectionHierarchy;

public class AddRemoveCollection extends Collection implements AddRemovable {


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
        int lastIndex = this.getItems().size() - 1;
        return this.getItems().remove(lastIndex);
    }
}
