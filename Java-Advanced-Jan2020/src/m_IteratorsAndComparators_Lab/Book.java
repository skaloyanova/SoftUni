package m_IteratorsAndComparators_Lab;

import java.util.Arrays;
import java.util.List;

public class Book implements Comparable<Book> {
    private String title;
    private int year;
    private List<String> authors;

    public Book(String title, int year, String... authors) {
        this.setTitle(title);
        this.setYear(year);
        this.setAuthors(authors);
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public int getYear() {
        return this.year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public List<String> getAuthors() {
        return this.authors;
    }

    public void setAuthors(String... authors) {
        this.authors = Arrays.asList(authors);
    }

    @Override
    public String toString() {
        return this.title + " <> " + this.year + " <>" + this.authors;
    }

    @Override
    public int compareTo(Book obj) {
        int resultByTitle = this.title.compareTo(obj.getTitle());

        if (resultByTitle == 0) {
            return Integer.compare(this.year, obj.getYear());
        }

        return resultByTitle;
    }
}
