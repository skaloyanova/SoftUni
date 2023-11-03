package z_Exam_20200222.guild;

public class Player {
    private String name;
    private String clazz;
    private String rank;  //"Trial" by default
    private String description;   //"n/a" by default

    public Player(String name, String clazz) {
        this.name = name;
        this.clazz = clazz;
        this.rank = "Trial";
        this.description = "n/a";
    }

    public String getName() {
        return name;
    }

    public String getClazz() {
        return clazz;
    }

    public String getRank() {
        return rank;
    }

    public void setRank(String rank) {
        this.rank = rank;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Player %s: %s%n", name, clazz));
        sb.append("Rank: ").append(rank).append(System.lineSeparator());
        sb.append("Description: ").append(description);

        return sb.toString();
    }
}
