package j_DefiningClasses_Exercises.FamilyTree;

public class Person {
    private String fullName;
    private String birthday;

    public Person(String fullName, String birthday) {
        this.fullName = fullName;
        this.birthday = birthday;
    }

    public String getFullName() {
        return fullName;
    }

    public String getBirthday() {
        return birthday;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public void setBirthday(String birthday) {
        this.birthday = birthday;
    }

    @Override
    public String toString() {
        return this.fullName + " " + this.birthday;
    }
}
