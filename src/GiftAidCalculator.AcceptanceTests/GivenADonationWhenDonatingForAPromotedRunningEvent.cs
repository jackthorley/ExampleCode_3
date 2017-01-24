namespace GiftAidCalculator.AcceptanceTests
{
    using Model.Events;
    using NUnit.Framework;

    [TestFixture]
    public class GivenADonationWhenDonatingForAPromotedRunningEvent
    {
        private decimal _donation;
        private decimal _expectedGiftAid;
        private decimal _giftAid;

        [SetUp]
        public void Given()
        {
            _expectedGiftAid = 30m;
            _donation = 100;

            var calculator = CalculatorFactory.Create();
            _giftAid = calculator.Execute(_donation, EventType.Running);
        }

        [Test]
        public void ThenTheCorrectGiftAidIsReturned()
        {
            Assert.That(_giftAid, Is.EqualTo(_expectedGiftAid));
        }
    }
}