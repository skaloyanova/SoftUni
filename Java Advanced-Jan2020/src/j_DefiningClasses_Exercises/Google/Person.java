package j_DefiningClasses_Exercises.Google;

import java.util.ArrayList;
import java.util.List;

public class Person {
    private String personName;      //unique
    private Company companyData;    //only 1, save only the lastly entered data
    private List<Pokemon> pokemonData;    //multiple
    private List<Parent> parentsData;     //multiple
    private List<Child> childrenData;     //multiple
    private Car carData;            //only 1, save only the lastly entered data

    public Person(String personName) {
        this.personName = personName;
        this.pokemonData = new ArrayList<>();
        this.parentsData = new ArrayList<>();
        this.childrenData = new ArrayList<>();
    }

    public void addCompany(String companyName, String department, double salary) {
        this.companyData = new Company(companyName, department, salary);
    }

    public void addData(String dataType, String param1, String param2) {
        //pokemon   <pokemonName> <pokemonType>"
        //parents   <parentName> <parentBirthday>"
        //children  <childName> <childBirthday>"
        //car       <carModel> <carSpeed>"
        switch (dataType) {
            case "pokemon": this.pokemonData.add(new Pokemon(param1, param2)); break;
            case "parents": this.parentsData.add(new Parent(param1, param2)); break;
            case "children": this.childrenData.add(new Child(param1, param2)); break;
            case "car": this.carData = new Car(param1, param2); break;
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(this.personName).append(System.lineSeparator());

        sb.append("Company:").append(System.lineSeparator());
        if (this.companyData != null) {
            sb.append(this.companyData).append(System.lineSeparator());
        }
        sb.append("Car:").append(System.lineSeparator());
        if (this.carData != null) {
            sb.append(this.carData).append(System.lineSeparator());
        }
        sb.append("Pokemon:").append(System.lineSeparator());
        for (Pokemon pokemon : pokemonData) {
            sb.append(pokemon).append(System.lineSeparator());
        }
        sb.append("Parents:").append(System.lineSeparator());
        for (Parent parent : parentsData) {
            sb.append(parent).append(System.lineSeparator());
        }
        sb.append("Children:").append(System.lineSeparator());
        for (Child child : childrenData) {
            sb.append(child).append(System.lineSeparator());
        }

       return sb.toString();
    }
}
