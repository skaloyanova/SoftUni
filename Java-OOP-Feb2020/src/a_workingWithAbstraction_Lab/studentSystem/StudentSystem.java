package a_workingWithAbstraction_Lab.studentSystem;

public class StudentSystem {
    private StudentRepository repo;

    public StudentSystem(StudentRepository repo) {
        this.repo = repo;
    }

    public String returnStudentInformation(String name) {
        Student student = repo.findByName(name);
        if (student != null) {
            return student.getStudentInformation();
        }
        return null;
    }

    public void saveUniqueStudentToRepo(Student student) {
        if (!repo.containsStudentWithName(student.getName())) {
            repo.save(student);
        }
    }
}
