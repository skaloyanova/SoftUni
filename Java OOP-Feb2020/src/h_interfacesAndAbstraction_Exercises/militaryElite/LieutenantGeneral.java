package h_interfacesAndAbstraction_Exercises.militaryElite;

import java.util.LinkedHashSet;
import java.util.Set;
import java.util.stream.Collectors;

public class LieutenantGeneral extends Private {
    private Set<Private> privatesList;

    public LieutenantGeneral(int id, String firstName, String lastName, double salary) {
        super(id, firstName, lastName, salary);
        this.privatesList = new LinkedHashSet<>();
    }

    public void addPrivate(Private priv) {
        privatesList.add(priv);
    }

    @Override
    public String toString() {
        String privatesString = "";
        if (!privatesList.isEmpty()) {
            privatesString = String.format("%n%s", privatesList.stream()
                    .sorted((f, s) -> Integer.compare(s.getId(), f.getId()))
                    .map(e -> String.format("  %s", e.toString()))
                    .collect(Collectors.joining(System.lineSeparator())));
        }
        return super.toString() + String.format("%nPrivates:%s", privatesString);

    }
}
