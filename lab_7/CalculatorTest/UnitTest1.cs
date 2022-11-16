namespace CalculatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void sumTest()
        {
            Assert.That(2, Is.EqualTo(Calculator.calculate("1+1")));
            Assert.That(2, Is.EqualTo(Calculator.calculate(1,1,'+')));
            Assert.That(2, Is.EqualTo(Calculator.calculate(1, 1, "+")));
        }

        [Test]
        public void minTest()
        {
            Assert.That(0, Is.EqualTo(Calculator.calculate("1-1")));
            Assert.That(0, Is.EqualTo(Calculator.calculate(1, 1, '-')));
            Assert.That(0, Is.EqualTo(Calculator.calculate(1, 1, "-")));
        }

        [Test]
        public void mulTest()
        {
            Assert.That(1, Is.EqualTo(Calculator.calculate("1*1")));
            Assert.That(1, Is.EqualTo(Calculator.calculate(1, 1, '*')));
            Assert.That(1, Is.EqualTo(Calculator.calculate(1, 1, "*")));
        }

        [Test]
        public void divTest()
        {
            Assert.That(1, Is.EqualTo(Calculator.calculate("1/1")));
            Assert.That(1, Is.EqualTo(Calculator.calculate(1, 1, '/')));
            Assert.That(1, Is.EqualTo(Calculator.calculate(1, 1, "/")));
        }

        [Test]
        public void wrongOperation()
        {
            Assert.Catch(typeof(Exception), () => Calculator.calculate("1.1"), "wrong operation");
            Assert.Catch(typeof(Exception), () => Calculator.calculate(1,1, '.'), "wrong operation");
            Assert.Catch(typeof(Exception), () => Calculator.calculate(1, 1, "."), "wrong operation");
        }

        [Test]
        public void noOperation()
        {
            Assert.Catch(() => Calculator.calculate("11"), "not valid count of arguments");
        }

        [Test]
        public void multipleOperations()
        {
            Assert.Catch(() => Calculator.calculate("1++1"), "not valid count of arguments");
        }

        [Test]
        public void noOperationSecondOverload()
        {
            Assert.Catch(() => Calculator.calculate(1,1,"++"), "not valid count of arguments");
        }

        [Test]
        public void bigNumbers()
        {
            Assert.That(1000, Is.EqualTo(Calculator.calculate("999+1")));
        }

        [Test]
        public void oneOperand()
        {
            Assert.Catch(() => Calculator.calculate("1+"), "not valid count of arguments");
        }
    }
}