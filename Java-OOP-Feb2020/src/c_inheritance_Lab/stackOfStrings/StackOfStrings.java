package c_inheritance_Lab.stackOfStrings;

import java.util.ArrayList;

public class StackOfStrings {
    private ArrayList<String> data;

    public StackOfStrings() {
        this.data = new ArrayList<>();
    }

    public void push(String item) {
        data.add(item);
    }

    public String pop() {
        if (isEmpty()) {
            return null;
        }
        return data.remove(data.size() - 1);
    }

    public String peek() {
        if (isEmpty()) {
            return null;
        }
        return data.get(this.data.size() - 1);
    }

    public boolean isEmpty() {
        return data.isEmpty();
    }
}
