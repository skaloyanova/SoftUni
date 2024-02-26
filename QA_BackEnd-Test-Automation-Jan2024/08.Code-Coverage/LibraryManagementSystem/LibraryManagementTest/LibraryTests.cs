using LibraryManagementSystem;

namespace LibraryManagementTest;

[TestFixture]
public class LibraryTests
{
    private Library _library;


    [SetUp]
    public void SetUp()
    {
        _library = new Library();
    }

    [Test]
    public void AddBook_ShouldAddBook_IfValidBookIsGiven()
    {
        //Arrange
        var book = new Book
        {
            Id = 1,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = false,
        };

        //Act
        _library.AddBook(book);

        //Assert
        var books = _library.GetAllBooks();
        Assert.That(books.Count(), Is.EqualTo(1));

        var bookInLibrary = books.FirstOrDefault();
        Assert.That(bookInLibrary.Id, Is.EqualTo(book.Id));
        Assert.That(bookInLibrary.Title, Is.EqualTo(book.Title));
        Assert.That(bookInLibrary.Author, Is.EqualTo(book.Author));
        Assert.That(bookInLibrary.IsCheckedOut, Is.EqualTo(book.IsCheckedOut));
    }

    [Test]
    public void CheckOutBook_ShouldReturnTrue_IfValidBookIdIsGivenAndBookIsNotCheckedOut()
    {
        //Arrange
        var book = new Book
        {
            Id = 5,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = false,
        };

        _library.AddBook(book);

        //Act
        var result = _library.CheckOutBook(book.Id);

        //Assert
        Assert.True(result);

        var bookInLiblary = _library.GetAllBooks().FirstOrDefault();
        Assert.That(bookInLiblary.IsCheckedOut, Is.EqualTo(true));
    }

    [Test]
    public void CheckOutBook_ShouldReturnFalse_IfBookIdIsNotValid()
    {
        //Arrange
        var book = new Book
        {
            Id = 1,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = false,
        };

        _library.AddBook(book);

        //Act
        var result = _library.CheckOutBook(100);

        //Assert
        Assert.False(result);
    }

    [Test]
    public void CheckOutBook_ShouldReturnFalse_IfBookIsAlreadyCheckedOut()
    {
        //Arrange
        var book = new Book
        {
            Id = 5,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = true,
        };

        _library.AddBook(book);

        //Act
        var result = _library.CheckOutBook(book.Id);

        //Assert
        Assert.False(result);
    }

    [Test]
    public void ReturnBook_ShouldReturnTrue_IfValidBookIdIsGivenAndBookIsAlreadyCheckedOut()
    {
        //Arrange
        var book = new Book
        {
            Id = 5,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = true,
        };

        _library.AddBook(book);

        //Act
        var result = _library.ReturnBook(book.Id);

        //Assert
        Assert.True(result);

        var bookInLiblary = _library.GetAllBooks().FirstOrDefault();
        Assert.False(bookInLiblary.IsCheckedOut);
    }

    [Test]
    public void ReturnBook_ShouldReturnFalse_IfBookIdIsNotValid()
    {
        //Arrange
        var book = new Book
        {
            Id = 1,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = false,
        };

        _library.AddBook(book);

        //Act
        var result = _library.ReturnBook(111);

        //Assert
        Assert.False(result);
    }

    [Test]
    public void ReturnBook_ShouldReturnFalse_IfBookIsNotCheckedOut()
    {
        //Arrange
        var book = new Book
        {
            Id = 5,
            Title = "Test title",
            Author = "Test author",
            IsCheckedOut = false,
        };

        _library.AddBook(book);

        //Act
        var result = _library.ReturnBook(book.Id);

        //Assert
        Assert.False(result);
    }

    [Test]
    public void GetAllBooks()
    {
        //Arrange

        //Act

        //Assert
    }
}

