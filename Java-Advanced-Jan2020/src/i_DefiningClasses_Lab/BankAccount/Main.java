package i_DefiningClasses_Lab.BankAccount;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<BankAccount> accounts = new ArrayList<>();

        String line = sc.nextLine();
        while (!"End".equals(line)) {
            String[] tokens = line.split("\\s+");

            switch (tokens[0]) {
                case "Create":
                    accounts.add(new BankAccount());
                    break;
                case "Deposit": {
                    int id = Integer.parseInt(tokens[1]);
                    double amount = Double.parseDouble(tokens[2]);
                    if (id > accounts.size() || id < 1) {
                        System.out.println("Account does not exist");
                    } else {
                        BankAccount currentAcc = accounts.get(id - 1);
                        currentAcc.deposit(amount);
                    }
                }
                    break;
                case "SetInterest": BankAccount.setInterestRate(Double.parseDouble(tokens[1])); break;
                case "GetInterest": {
                    int id = Integer.parseInt(tokens[1]);
                    int years = Integer.parseInt(tokens[2]);
                    if (id > accounts.size() || id < 1) {
                        System.out.println("Account does not exist");
                    } else {
                        BankAccount currentAcc = accounts.get(id - 1);
                        double interest = currentAcc.getInterest(years);
                        System.out.println(String.format("%.2f", interest));
                    }
                }
            }

            line = sc.nextLine();
        }

    }
}
