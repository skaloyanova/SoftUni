package h_interfacesAndAbstraction_Exercises.militaryElite;

import java.util.*;
import java.util.stream.Collectors;

public class Commando extends SpecialisedSoldier {
    Set<Mission> missions;

    public Commando(int id, String firstName, String lastName, double salary, String corp) {
        super(id, firstName, lastName, salary, corp);
        this.missions = new LinkedHashSet<>();
    }

    public void addMission(Mission mission) {
        missions.add(mission);
    }

    public Collection<Mission> getMissions() {
        return Collections.unmodifiableCollection(missions);
    }

    @Override
    public String toString() {
        String missionsString = "";
        if (!missions.isEmpty()) {
            missionsString = String.format("%n%s",missions.stream()
                    .map(e -> String.format("  %s", e.toString()))
                    .collect(Collectors.joining(System.lineSeparator())));
        }
        return super.toString() + String.format("%nMissions:%s", missionsString);
    }

}
