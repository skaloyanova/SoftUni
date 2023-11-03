package a_workingWithAbstraction_Lab.studentSystem;

public interface StudentRepository {

    /**
     * Checks if Student with the given name exists in the Repository.
     *
     * @param name of the student.
     * @return true if Student is present, otherwise returns false.
     */
    boolean containsStudentWithName(String name);

    /**
     * Given a student name, return a student from the repository.
     *
     * @param name of the student.
     * @return the Student if present. If not present, return null.
     */
    Student findByName(String name);

    /**
     * Saves the Student in Repository
     *
     * @param student to save
     */
    void save(Student student);
}
