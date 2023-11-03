package z_Exam_20200222.guild;

import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class Guild {
    private String name;
    private int capacity;
    private Map<String, Player> roster;

    public Guild(String name, int capacity) {
        this.name = name;
        this.capacity = capacity;
        this.roster = new LinkedHashMap<>();
    }

    public void addPlayer(Player player) {
        if (roster.size() < capacity) {
            roster.put(player.getName(), player);
        }
    }

    public boolean removePlayer(String name) {
        if (roster.containsKey(name)) {
            roster.remove(name);
            return true;
        }
        return false;
    }

    public void promotePlayer(String name) {
        roster.get(name).setRank("Member");
    }

    public void demotePlayer(String name) {
        roster.get(name).setRank("Trial");
    }

    public Player[] kickPlayersByClass(String clazz) {
       List<Player> temp = roster.values().stream()
                .filter(e -> e.getClazz().equals(clazz)).collect(Collectors.toList());

       Player[] kicked = new Player[temp.size()];
        for (int i = 0; i < temp.size(); i++) {
            kicked[i] = temp.get(i);
            roster.remove(temp.get(i).getName());
        }

        return kicked;
    }

    public int count() {
        return this.roster.size();
    }

    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Players in the z_Exam_20200222.guild: %s:%n", name));
        sb.append(roster.values().stream().map(Player::toString).collect(Collectors.joining(System.lineSeparator())));

        return sb.toString();
    }
}
