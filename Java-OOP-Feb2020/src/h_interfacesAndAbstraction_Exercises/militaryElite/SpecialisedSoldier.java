package h_interfacesAndAbstraction_Exercises.militaryElite;

public class SpecialisedSoldier extends Private{
    private String corp;

    public SpecialisedSoldier(int id, String firstName, String lastName, double salary, String corp) {
        super(id, firstName, lastName, salary);
        this.setCorp(corp);
    }

    private void setCorp(String corp) {
        try {
            Corp.valueOf(corp);
        } catch (Exception e) {
          throw new IllegalArgumentException("invalid corp");
        }
        this.corp = corp;
    }

    @Override
    public String toString() {
        return super.toString() + String.format("%nCorps: %s", corp);
    }
}
