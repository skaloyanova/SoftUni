package n_AssociativeArrays_Exercise;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

public class CompanyUsers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        HashMap<String, List<String>> companyUsers = new HashMap<>();

        String input = sc.nextLine();

        while(!"End".equals(input)) {
            String[] tokens = input.split(" -> ");

            String company = tokens[0];
            String eid = tokens[1];

            companyUsers.putIfAbsent(company, new ArrayList<>());
            if (!companyUsers.get(company).contains(eid)) {
                companyUsers.get(company).add(eid);
            }

            input = sc.nextLine();
        }

        companyUsers.entrySet().stream()
                .sorted((k1,k2) -> k1.getKey().compareTo(k2.getKey()))
                .forEach(c -> {
                    System.out.println(c.getKey());
                    c.getValue().forEach(e -> System.out.println("-- " + e));
                });
    }
}
