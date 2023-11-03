package g_interfacesAndAbstraction_Lab.carShopExtended;

public interface Car {
    //public static final -> is default
    int TIRES = 4;

    //public abstract -> is default
    String getModel();

    String getColor();

    Integer getHorsePower();

    String countryProduced();

}
