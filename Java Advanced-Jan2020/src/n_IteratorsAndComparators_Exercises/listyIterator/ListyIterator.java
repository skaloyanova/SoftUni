package n_IteratorsAndComparators_Exercises.listyIterator;

import java.util.*;

public class ListyIterator implements Iterable<String> {

    private List<String> data;
    private int index;

    public ListyIterator(String... elements) {
        create(elements);
        this.index = 0;
    }

    public void create (String... elements) {
        if (elements.length == 0) {
            this.data = new ArrayList<>();
        } else {
            this.data = Arrays.asList(elements);
        }
    }

    public boolean move() {
        if (this.hasNext()) {
            this.index++;
            return true;
        }
        return false;
    }

    public String print() {
        if (data.size() == 0) {
            throw new NoSuchElementException ("Invalid Operation!");
        }

        return this.data.get(index);
    }

    public String PrintAll() {
        if (data.size() == 0) {
            throw new NoSuchElementException("Invalid Operation!");
        }
        StringBuilder sb = new StringBuilder();
        for (String d : data) {
            sb.append(d).append(" ");
        }
        return sb.toString();
    }

    public boolean hasNext() {
        return index + 1 < data.size();
    }

    @Override
    public Iterator<String> iterator() {
        return new Iterator<String>() {

            private int idx;
            @Override
            public boolean hasNext() {
                return idx < data.size();
            }

            @Override
            public String next() {
                return data.get(idx++);
            }
        };
    }
}
