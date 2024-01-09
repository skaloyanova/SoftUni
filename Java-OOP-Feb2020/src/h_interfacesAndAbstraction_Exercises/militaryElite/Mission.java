package h_interfacesAndAbstraction_Exercises.militaryElite;

public class Mission {
    private String codeName;
    private String state;

    public Mission(String codeName, String state) {
        this.codeName = codeName;
        this.setState(state);
    }

    private void setState(String state) {
       try {
           State.valueOf(state);
       } catch (Exception e) {
           throw new IllegalArgumentException("invalid mission state");
       }
        this.state = state;
    }

    public void completeMission() {
        this.state = "Finished";
    }

    @Override
    public String toString() {
        return String.format("Code Name: %s h_interfacesAndAbstraction_Exercises.militaryElite.State: %s", codeName, state);
    }
}
