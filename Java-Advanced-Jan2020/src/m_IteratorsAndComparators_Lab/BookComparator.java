package m_IteratorsAndComparators_Lab;

import java.util.Comparator;

public class BookComparator implements Comparator<Book> {

    @Override
    public int compare(Book obj1, Book obj2) {
        int compareByTitle = obj1.getTitle().compareTo(obj2.getTitle());

        if (compareByTitle == 0) {
            return Integer.compare(obj1.getYear(), obj2.getYear());
        }
        return compareByTitle;
    }
}
