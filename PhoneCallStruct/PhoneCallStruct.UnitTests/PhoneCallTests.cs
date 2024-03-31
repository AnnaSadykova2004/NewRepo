namespace PhoneCallStruct.UnitTests
{
    [TestFixture]
    public class PhoneCallTests
    {
        [Test]
        public void ConstructorTest()
        {
            var phoneCall = new PhoneCall(135, 2.5);

            Assert.That(phoneCall.Time, Is.EqualTo(135));
            Assert.That(phoneCall.Rate, Is.EqualTo(2.5));
        }

        [TestCase(120, 2.5, 5)]
        [TestCase(90, 2.5, 3.75)]

        public void CostTest(int time, double rate, double result)
        {
            var phoneCall = new PhoneCall(time, rate);

            Assert.That(phoneCall.Cost, Is.EqualTo(result));
        }

        [TestCase(-10)]
        [TestCase(0)]

        public void TimeSet_NotPositive_ArgumentException(int val)
        {
            var phoneCall = new PhoneCall();

            Assert.That(() => phoneCall.Time = val, Throws.ArgumentException);
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void TimeRate_NotPositive_ArgumentException(int val)
        {
            var phoneCall = new PhoneCall();

            Assert.That(() => phoneCall.Rate = val, Throws.ArgumentException);
        }

        [TestCase(135, 2.5, "Разговор: 135 c по 2,5 руб./мин")]
        public void ToStringTest(int time, double rate, string result)
        {
            var phoneCall = new PhoneCall(time, rate);
            Assert.That(phoneCall.ToString(), Is.EqualTo(result));
        }

        [TestCase(130, 130, true)]
        [TestCase(130, 150, false)]
        public void Equals_PhoneCall_ExpectedResult(int a1, int a2, bool result)
        {
            var phoneCall1 = new PhoneCall(a1, 3.5);
            var phoneCall2 = new PhoneCall(a2, 3.5);
            Assert.That(phoneCall1.Equals(phoneCall2), Is.EqualTo(result));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var phoneCall = new PhoneCall();
            var smth = new object();
            Assert.That(() => phoneCall.Equals(smth), Throws.ArgumentException);
        }

        [Test]
        public static void GetHashCodeTest()
        {
            var x = new PhoneCall(135, 2.5).GetHashCode();
            var y = new PhoneCall(135, 2.5).GetHashCode();
            var z = new PhoneCall(250, 3).GetHashCode();
            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }

        [TestCase(130, 110, 240)]
        [TestCase(5, 215, 220)]
        public void AdditionTest(int time1, int time2, int resultTime)
        {
            var phoneCall1 = new PhoneCall(time1, 2.5);
            var phoneCall2 = new PhoneCall(time2, 2.5);
            var result = new PhoneCall(resultTime, 2.5);

            Assert.That(phoneCall1 + phoneCall2, Is.EqualTo(result));
        }

        [TestCase(2.5, 4)]
        [TestCase(5, 1.2)]

        public void Addition_DifferentRate_ArgumentException(double rate1, double rate2)
        {
            var phoneCall1 = new PhoneCall(150, rate1);
            var phoneCall2 = new PhoneCall(620, rate2);

            Assert.That(() => phoneCall1 + phoneCall2, Throws.ArgumentException);
        }

        [TestCase(2.5, 5, 2)]
        [TestCase(1.2, 3.6, 3)]

        public void MultiplicationTest(double rate, double resultRate, double k)
        {
            var phoneCall = new PhoneCall(120, rate);
            var result = new PhoneCall(120, rate * k);

            Assert.That(phoneCall * k, Is.EqualTo(result));
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void Multiplication_NotPositive_ArgumentException(double k)
        {
            var phoneCall = new PhoneCall(120, 3.8);

            Assert.That(() => phoneCall * k, Throws.ArgumentException);
        }
    }
}