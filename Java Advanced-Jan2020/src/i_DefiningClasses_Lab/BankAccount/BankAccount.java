package i_DefiningClasses_Lab.BankAccount;

import java.text.DecimalFormat;

public class BankAccount {
    private static double interestRate = 0.02;    // Shared for all accounts. Default value: 0.02
    private static int bankAccountCount = 1;

    private int id;     //Starts from 1 and increments for every new account
    private double balance;

    public BankAccount() {
        this.id = bankAccountCount++;
        System.out.println(String.format("Account ID%d created", this.id));
    }

    public static void setInterestRate(double interestRate) {
        BankAccount.interestRate = interestRate;
    }

    public double getInterest(int years) {
        return years * this.balance * interestRate;
    }

    public void deposit(double amount) {
        this.balance += amount;
        DecimalFormat df = new DecimalFormat("#.##");
        System.out.println(String.format("Deposited %s to ID%d", df.format(amount), this.id));
    }
}
