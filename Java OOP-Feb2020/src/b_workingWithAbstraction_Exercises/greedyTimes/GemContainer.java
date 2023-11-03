package b_workingWithAbstraction_Exercises.greedyTimes;

import java.util.LinkedHashMap;
import java.util.Map;

public class GemContainer {
    private Map<String, Long> gems;

    public GemContainer() {
        this.gems = new LinkedHashMap<>();
    }

    public long getTotalValue() {
        return this.gems.values()
                .stream()
                .mapToLong(e -> e)
                .sum();
    }

    public void add(String item, long amount){
        this.gems.putIfAbsent(item, 0L);
        this.gems.put(item, this.gems.get(item) + amount);
    }

    public boolean isEmpty() {
        return gems.isEmpty();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        this.gems.entrySet()
                .stream()
                .sorted((f,s) -> {
                    int result = s.getKey().compareTo(f.getKey());
//                    if (result == 0) {
//                        result = f.getValue().compareTo(s.getValue());
//                    }
                    return result;
                })
                .forEach(e -> {
                    sb.append("##").append(e.getKey());
                    sb.append(" - ").append(e.getValue());
                    sb.append(System.lineSeparator());
                });
        return sb.toString();
    }
}
