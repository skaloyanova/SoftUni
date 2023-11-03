package l_ObjectsAndClasses_Exercise.xCompanyRoster;

public class Employee {
    private String name;
    private double salary;
    private String position;
    private String department;
    private String email;   //opt
    private int age;        //opt

    public Employee(String name, double salary, String position, String department, String email, int age) {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %s %d",this.name, this.salary, this.email, this.age );
    }

    public String getDepartment() {
        return department;
    }

    public double getSalary() {
        return salary;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setAge(int age) {
        this.age = age;
    }
}
