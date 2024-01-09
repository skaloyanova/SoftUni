using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        //Arrange
        double balance = 2.5;
        BankAccount bankAccount = new BankAccount(balance);

        //Act
        double result = bankAccount.Balance;

        //Assert
        Assert.That(result, Is.EqualTo(balance));
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        //Arrange
        double deposit = 10.5;
        BankAccount bankAccount = new BankAccount(100);
        double expected = 110.5;

        //Act
        bankAccount.Deposit(deposit);
        double result = bankAccount.Balance;

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        //Arrange
        double deposit = -10.5;
        BankAccount bankAccount = new BankAccount(100);

        //Act & Assert
        Assert.That(() => bankAccount.Deposit(deposit), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        //Arrange
        double withdraw = 50.5;
        BankAccount bankAccount = new BankAccount(100.5);
        double expected = 50;

        //Act
        bankAccount.Withdraw(withdraw);
        double result = bankAccount.Balance;

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        //Arrange
        double withdraw = -10.5;
        BankAccount bankAccount = new BankAccount(100);

        //Act & Assert
        Assert.That(() => bankAccount.Withdraw(withdraw), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        //Arrange
        double withdraw = 50.5;
        BankAccount bankAccount = new BankAccount(50);

        //Act & Assert
        Assert.That(() => bankAccount.Withdraw(withdraw), Throws.ArgumentException);
    }
}
