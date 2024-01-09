package f_encapsulation_Exercises.footballTeamGenerator;

import java.util.ArrayList;
import java.util.List;

public class Team {
    private String name;
    private List<Player> players;

    public Team(String name) {
        this.setName(name);
        this.players = new ArrayList<>();
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

    public void addPlayer(Player player) {
        players.add(player);
    }

    public void removePlayer(String playerName) {
        if (!players.removeIf(p -> p.getName().equals(playerName))) {
            throw new IllegalStateException(String.format("f_encapsulation_Exercises.footballTeamGenerator.Player %s is not in %s team.", playerName, this.name));
        }
    }

    public double getRating() {
        return Math.round(players.stream().mapToDouble(Player::overallSkillLevel).average().orElse(0.0));
    }
}
