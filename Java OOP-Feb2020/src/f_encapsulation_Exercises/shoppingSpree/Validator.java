package f_encapsulation_Exercises.shoppingSpree;

public class Validator {

    //encapsulate f_encapsulation_Exercises.shoppingSpree.Validator, in order to be unable to create new Instance of f_encapsulation_Exercises.shoppingSpree.Validator,
    // as all of its methods are static, as it will be confusable to be able to create instances
    private Validator() {

    }

    public static void validateName(String name) {
        if (name == null || name.trim().isEmpty()) {
            throw new IllegalArgumentException("Name cannot be empty");
        }
    }

    public static void validateMoney(double money) {
        if (money < 0) {
            throw new IllegalArgumentException("Money cannot be negative");
        }
    }
}
