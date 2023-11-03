package e_encapsulation_Lab;

import java.security.InvalidParameterException;

public class Person {
    private String firstName;
    private String lastName;
    private int age;
    private double salary;

    public Person(String firstName, String lastName, int age) {
        setFirstName(firstName);
        setLastName(lastName);
        setAge(age);
    }

    public Person(String firstName, String lastName, int age, double salary) {
        this(firstName, lastName, age);
        setSalary(salary);
    }

    public void setFirstName(String firstName) {
        if (firstName.length() < 3) {
            throw new IllegalArgumentException("First name cannot be less than 3 symbols");
        }
        this.firstName = firstName;
    }

    public void setLastName(String lastName) {
        if (lastName.length() < 3) {
            throw new IllegalArgumentException("Last name cannot be less than 3 symbols");
        }
        this.lastName = lastName;
    }

    public void setAge(int age) {
        if (age <= 0) {
            throw new IllegalArgumentException("Age cannot be zero or negative integer");
        }
        this.age = age;
    }

    public void setSalary(double salary) {
        if (salary < 460) {
            throw new IllegalArgumentException("Salary cannot be less than 460 leva");
        }
        this.salary = salary;
    }

    public void increaseSalary(double bonus) {
        if (age < 30) {
            bonus = bonus / 2;
        }
        salary += salary * bonus / 100;
    }

    public double getSalary() {
        return salary;
    }

    public String getFirstName() {
        return firstName;
    }

    public int getAge() {
        return age;
    }

    /*
    1. Sort by Name and Age
    */
    @Override
    public String toString() {
        return firstName + " " + lastName + " is " + age + " years old.";
    }

    /*
    2. Salary Increase
    */
//    @Override
//    public String toString() {
//        return String.format("%s %s gets %f leva", firstName, lastName, salary);
//    }

}
