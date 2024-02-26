namespace SimpleArray;

public class MyArrayTests

{
    private MyArray _arr;

    [SetUp]
    public void Setup()
    {
        _arr = new MyArray(4);
    }

    [Test]
    public void Replace_ShouldReplaceValue_WhenValidPositionIsGiven()
    {
        //Act
        var result = _arr.Replace(2, 25);

        //Assert
        Assert.True(result);
        Assert.That(_arr.Array, Has.Length.EqualTo(4));
        Assert.That(_arr.Array[2], Is.EqualTo(25));
    }

    [Test]
    public void Replace_ShouldThrowException_IfNegativePositionIsGiven()
    {
        //Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _arr.Replace(-1, 15));
        Assert.That(exception.Message, Is.EqualTo("Position must not be less than zero"));
    }

    [Test]
    public void Replace_ShouldThrowException_IfInvalidPositionIsGiven()
    {
        //Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _arr.Replace(_arr.Array.Length, 13));
        Assert.That(exception.Message, Is.EqualTo("Position must be valid"));
    }

    [Test]
    public void ShouldReturnMaxElement_IfArrayIsNotEmpty()
    {
        var result = _arr.FindMax();

        Assert.That(result, Is.EqualTo(3));

    }

    [Test]
    public void ShouldThrowException_IfArrayIsEmpty()
    {
        var emptyArr = new MyArray(0);

        var exception = Assert.Throws<InvalidOperationException>(() => emptyArr.FindMax());
    }

}