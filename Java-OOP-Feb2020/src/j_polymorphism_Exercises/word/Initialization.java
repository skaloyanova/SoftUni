package j_polymorphism_Exercises.word;

public class Initialization {
    public static CommandInterface buildCommandInterface(StringBuilder text) {
        CommandInterface ci = new CommandImpl(text);
        ci.init();
        return ci;
    }
}
