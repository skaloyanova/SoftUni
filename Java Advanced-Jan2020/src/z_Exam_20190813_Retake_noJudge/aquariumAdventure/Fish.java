package z_Exam_20190813_Retake_noJudge.aquariumAdventure;

public class Fish {
    private String name;
    private String color;
    private int fins;

    public Fish(String name, String color, int fins) {
        this.name = name;
        this.color = color;
        this.fins = fins;
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Fish: ").append(this.name).append(System.lineSeparator());
        sb.append("Color: ").append(this.color).append(System.lineSeparator());
        sb.append("Number of fins: ").append(this.fins);

        return sb.toString();
    }
}
