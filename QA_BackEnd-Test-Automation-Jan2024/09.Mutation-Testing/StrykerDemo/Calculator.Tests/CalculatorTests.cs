namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private CalculatorEngine _engine;

        [SetUp]
        public void Setup()
        {
            _engine = new CalculatorEngine();
        }

        [TestCase(5, 5, 10)]
        public void TestSumMethod(int firstNum, int secondNum, int expected)
        {
            var result = _engine.Sum(firstNum, secondNum);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 5, 0)]
        public void TestSubtractMethod(int firstNum, int secondNum, int expected)
        {
            var result = _engine.Subtract(firstNum, secondNum);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 5, 25)]
        //[TestCase(1, 1, 1)]
        public void TestMultiplyMethod(int firstNum, int secondNum, int expected)
        {
            var result = _engine.Multiply(firstNum, secondNum);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 5, 1)]
        //[TestCase(1, 1, 1)]
        public void TestDivideMethod(int firstNum, int secondNum, int expected)
        {
            var result = _engine.Divide(firstNum, secondNum);

            Assert.That(result, Is.EqualTo(expected));
        }


        [TestCase(5, 0)]
        public void TestDivideMethod_ThrowsException(int firstNum, int secondNum)
        {
            //Assert.Throws<DivideByZeroException>(() => _engine.Divide(firstNum, secondNum));
            Assert.Throws<ArgumentException>(() => _engine.Divide(firstNum, secondNum));
        }
    }
}