using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange

        // Act

        // Assert
        //Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange

        // Act & Assert
        //Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // TODO: finish test
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange

        // Act & Assert
        //Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // TODO: finish test
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange

        // Act & Assert
        //Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // TODO: finish test
    }
}
