package b_workingWithAbstraction_Exercises.greedyTimes;

public class Bag {
    private long capacity;
    private Gold gold;
    private GemContainer gemContainer;
    private CashContainer cashContainer;

    public Bag(long capacity) {
        this.capacity = capacity;
        this.gold = new Gold();
        this.gemContainer = new GemContainer();
        this.cashContainer = new CashContainer();
    }

    public long getFreeCapacity() {
        return this.capacity - (this.getGoldValue() + this.getGemsValue() + this.getCashValue());
    }

    public long getGemsValue() {
        return gemContainer.getTotalValue();
    }

    public long getCashValue() {
        return cashContainer.getTotalValue();
    }

    public long getGoldValue() {
        return gold.getValue();
    }

    public boolean hasEnoughCapacity(long amount) {
        return this.getFreeCapacity() >= amount;
    }

    public void add(String type, String item, Long amount) {

        // gold >= gem >= cash

        switch (type) {
            case "Gold":
                gold.add(amount);
                break;
            case "Gem":
                if (this.getGemsValue() + amount <= this.getGoldValue()) {
                    gemContainer.add(item, amount);
                }
                break;
            case "Cash":
                if (this.getCashValue() + amount <= this.getGemsValue()) {
                    cashContainer.add(item, amount);
                }
                break;
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        if (!gold.isEmpty()) {
            sb.append("<Gold> $").append(this.getGoldValue()).append(System.lineSeparator());
            sb.append(gold.toString());
        }

        if (!gemContainer.isEmpty()) {
            sb.append("<Gem> $").append(gemContainer.getTotalValue()).append(System.lineSeparator());
            sb.append(gemContainer.toString());
        }

        if (!cashContainer.isEmpty()) {
            sb.append("<Cash> $").append(cashContainer.getTotalValue()).append(System.lineSeparator());
            sb.append(cashContainer.toString());
        }
        return sb.toString();
    }
}
