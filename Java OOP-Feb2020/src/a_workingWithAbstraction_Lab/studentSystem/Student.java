package a_workingWithAbstraction_Lab.studentSystem;

public class Student {
    private String name;
    private int age;
    private double grade;

    public Student(String name, int age, double grade) {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }

    public String getStudentInformation() {
        String comment = createCommentaryBasedOnGrade();
        return String.format("%s is %s years old. %s", this.name, this.age, comment);
    }

    private String createCommentaryBasedOnGrade() {
        if (this.grade >= 5.00) {
            return "Excellent student.";
        } else if (this.grade >= 3.50) {
            return "Average student.";
        } else {
            return "Very nice person.";
        }
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public double getGrade() {
        return grade;
    }

    public void setGrade(double grade) {
        this.grade = grade;
    }
}
