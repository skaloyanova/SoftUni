package j_polymorphism_Exercises.calculator;

public class Extensions {


    public static InputInterpreter buildInterpreter(CalculationEngine engine) {
        return new InputInterpreter(engine);
    }
}
