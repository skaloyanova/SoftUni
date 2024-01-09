package f_encapsulation_Exercises.footballTeamGenerator;

public class Player {
    private String name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(String name, int endurance, int sprint, int dribble, int passing, int shooting) {
        this.setName(name);
        this.setEndurance(endurance);
        this.setSprint(sprint);
        this.setDribble(dribble);
        this.setPassing(passing);
        this.setShooting(shooting);
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        if (name == null || name.trim().isEmpty()) {
            throw new IllegalArgumentException("A name should not be empty.");
        }
        this.name = name;
    }

    private void setEndurance(int endurance) {
        validateStat("Endurance", endurance);
        this.endurance = endurance;
    }

    private void setSprint(int sprint) {
        validateStat("Sprint", sprint);
        this.sprint = sprint;
    }

    private void setDribble(int dribble) {
        validateStat("Dribble", dribble);
        this.dribble = dribble;
    }

    private void setPassing(int passing) {
        validateStat("Passing", passing);
        this.passing = passing;
    }

    private void setShooting(int shooting) {
        validateStat("Shooting", shooting);
        this.shooting = shooting;
    }

    public double overallSkillLevel() {
        return (endurance + sprint + dribble + passing + shooting) / 5.0;
    }

    private void validateStat(String statType, int stat) {
        if (stat < 0 || stat > 100) {
            throw new IllegalArgumentException(statType + " should be between 0 and 100.");
        }
    }
}
