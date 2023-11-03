package b_workingWithAbstraction_Exercises.greedyTimes;

import java.util.LinkedHashMap;
import java.util.Map;

public class CashContainer {
    private Map<String, Long> cash;

    public CashContainer(){
        this.cash = new LinkedHashMap<>();
    }

    public long getTotalValue() {
        return this.cash.values()
                .stream()
                .mapToLong(e -> e)
                .sum();
    }

    public void add(String item, long amount){
        this.cash.putIfAbsent(item, 0L);
        this.cash.put(item, this.cash.get(item) + amount);
    }

    public boolean isEmpty() {
        return cash.isEmpty();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        this.cash.entrySet()
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
