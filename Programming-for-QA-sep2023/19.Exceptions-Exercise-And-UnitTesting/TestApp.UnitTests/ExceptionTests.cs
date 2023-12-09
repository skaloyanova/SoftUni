using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "StuN+";
        string expected = "+NutS";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [TestCase(100.5, 0, 100.5)]
    [TestCase(100.5, 10, 90.45)]
    [TestCase(100.5, 100, 0)]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice(decimal totalPrice, decimal discount, decimal expected)
    {
        //Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.5m;
        decimal discount = -0.0009m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 100.001m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [TestCase(new[] { 1, 2, 3, 4 }, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 3)]
    [TestCase(new[] { 1, 2, 3, 4 }, 3, 4)]
    public void Test_GetElement_ValidIndex_ReturnsElement(int[] array, int index, int expected)
    {
        //Act
        int result = this._exceptions.IndexOutOfRangeGetElement(array, index);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1 };
        int index = -1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int index = array.Length + 1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        bool loggedIn = true;
        string expected = "User logged in.";

        string result = this._exceptions.InvalidOperationPerformSecureOperation(loggedIn);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        bool loggedIn = false;

        Assert.That(() => this._exceptions.InvalidOperationPerformSecureOperation(loggedIn), Throws.InvalidOperationException);
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        string input = "51";
        int expected = 51;

        int result = this._exceptions.FormatExceptionParseInt(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        string input = "51a";

        Assert.That(() => this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        //Arrange
        Dictionary<string, int> dictionary = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
        };
        string key = "two";
        int expected = 2;

        //Act
        int result = this._exceptions.KeyNotFoundFindValueByKey(dictionary, key);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, int> dictionary = new()
        {
            { "key1", 100},
            { "key2", 200},
            { "key3", 300},
        };
        string key = "key";

        //Act & Assert
        Assert.That(() => this._exceptions.KeyNotFoundFindValueByKey(dictionary, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        int a = 10;
        int b = 100000;
        int expected = 100010;

        int result = this._exceptions.OverflowAddNumbers(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        int a = int.MaxValue;
        int b = 5;

        Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        int a = int.MinValue;
        int b = -5;

        Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [TestCase(0, 5, 0)]
    [TestCase(50, 5, 10)]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient(int a, int b, int expected)
    {
        int result = this._exceptions.DivideByZeroDivideNumbers(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        int a = 5;
        int b = 0;

        Assert.That(() => this._exceptions.DivideByZeroDivideNumbers(a, b), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        int[] input = { 1, 2, 3 };
        int index = 2;
        int expected = 6;

        int result = this._exceptions.SumCollectionElements(input, index);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        int[]? input = null;
        int index = 2;

        Assert.That(() => this._exceptions.SumCollectionElements(input, index), Throws.ArgumentNullException);
    }

    [TestCase(new int[] { 1, 3 }, -1)]
    [TestCase(new int[] { 1, 3 }, 2)]
    [TestCase(new int[] { 1, 3 }, 5)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int[] input, int index)
    {
        Assert.That(() => this._exceptions.SumCollectionElements(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        //Arrange
        Dictionary<string, string> dictionary = new()
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
        };
        string key = "three";
        int expected = 3;

        //Act
        int result = this._exceptions.GetElementAsNumber(dictionary, key);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, string> dictionary = new()
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
        };
        string key = "four";

        //Act & Assert
        Assert.That(() => this._exceptions.GetElementAsNumber(dictionary, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        //Arrange
        Dictionary<string, string> dictionary = new()
        {
            { "one", "1" },
            { "two", "2a" },
            { "three", "3" },
        };
        string key = "two";

        //Act & Assert
        Assert.That(() => this._exceptions.GetElementAsNumber(dictionary, key), Throws.InstanceOf<FormatException>());
    }
}
