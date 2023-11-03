package m_IteratorsAndComparators_Lab;

import java.util.Iterator;

public class Library implements Iterable<Book> {

    private Book[] books;

    public Library(Book... books) {
        this.books = books;
    }

    @Override
    public Iterator<Book> iterator() {
        return new LibIterator(this.books);
    }

    public static class LibIterator implements Iterator<Book> {

        private Book[] libBooks;
        private int counter;

        public LibIterator(Book[] books) {
            this.libBooks = books;
            this.counter = 0;
        }

        @Override
        public boolean hasNext() {
            return counter < libBooks.length;
        }

        @Override
        public Book next() {
            return libBooks[counter++];
        }
    }
}
