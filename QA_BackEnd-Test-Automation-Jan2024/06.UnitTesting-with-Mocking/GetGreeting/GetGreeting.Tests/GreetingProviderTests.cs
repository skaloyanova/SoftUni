using Moq;

namespace GetGreeting.Tests
{
    public class GreetingProviderTests
    {
        private GreetingProvider _greetingProvider;
        private Mock<ITimeProvider> _timeProviderMock;

        [SetUp]
        public void SetUp()
        {
            _timeProviderMock = new Mock<ITimeProvider>();
            _greetingProvider = new GreetingProvider(_timeProviderMock.Object);
        }

        [Test]
        public void GetGreeting_ShouldReturnMorningMessage_WhenItIsMorning()
        {
            //Arrange
            _timeProviderMock.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2024, 2, 12, 9, 10, 0));

            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo("Good morning!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnAfternoonMessage_WhenItIsAfternoon()
        {
            //Arrange
            _timeProviderMock.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2024, 2, 19, 13, 5, 0));

            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo("Good afternoon!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnEveningMessage_WhenItIsEvening()
        {
            //Arrange
            _timeProviderMock.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2024, 2, 19, 21, 0, 0));

            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo("Good evening!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnNightMessage_WhenItIsNight()
        {
            //Arrange
            _timeProviderMock.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2024,2,19,0,0,0));

            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo("Good night!"));
        }

        [TestCase("Good morning!", 6)]
        [TestCase("Good afternoon!", 14)]
        [TestCase("Good evening!", 19)]
        [TestCase("Good night!", 23)]
        public void GetGreeting_ShouldReturnCorrectMessage_WhenTimeIsCorrect(string expectedMessage, int currentHour)
        {
            //Arrange
            _timeProviderMock.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2024, 2, 19, currentHour, 0, 0));

            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo(expectedMessage));
        }
    }
}