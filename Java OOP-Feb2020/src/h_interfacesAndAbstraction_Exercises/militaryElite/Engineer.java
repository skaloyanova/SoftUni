package h_interfacesAndAbstraction_Exercises.militaryElite;

import java.util.*;
import java.util.stream.Collectors;

public class Engineer extends SpecialisedSoldier {
    private Set<Repair> repairs;

    public Engineer(int id, String firstName, String lastName, double salary, String corp) {
        super(id, firstName, lastName, salary, corp);
        this.repairs = new LinkedHashSet<>();
    }

    public void addRepair(Repair repair) {
        repairs.add(repair);
    }

    public Collection<Repair> getRepairs() {
        return Collections.unmodifiableCollection(repairs);
    }

    @Override
    public String toString() {
        String repairsString = "";
        if (!repairs.isEmpty()) {
            repairsString = String.format("%n%s", repairs.stream()
                    .map(e -> String.format("  %s", e.toString()))
                    .collect(Collectors.joining(System.lineSeparator())));
        }
        return super.toString() + String.format("%nRepairs:%s", repairsString);
    }
}
