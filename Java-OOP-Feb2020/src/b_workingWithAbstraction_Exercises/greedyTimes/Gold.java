package b_workingWithAbstraction_Exercises.greedyTimes;

public class Gold {
    private long value;
    private boolean isEmpty;

    public Gold() {
        this.isEmpty = true;
    }

    public long getValue() {
        return value;
    }

    public void add(long amount){
        this.value += amount;
        this.isEmpty = false;
    }

    public boolean isEmpty() {
        return this.isEmpty;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("##Gold - ").append(value).append(System.lineSeparator());
        return sb.toString();
    }
}
