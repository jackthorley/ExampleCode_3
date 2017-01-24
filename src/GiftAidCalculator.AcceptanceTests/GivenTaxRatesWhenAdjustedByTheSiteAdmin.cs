namespace GiftAidCalculator.AcceptanceTests
{
    using Helpers;
    using Model.Events;
    using NUnit.Framework;

    [TestFixture]
    public class GivenTaxRatesWhenAdjustedByTheSiteAdmin
    {
        private const int FirstTaxationRate = 20;
        private const decimal SecondTaxationRate = 1.5m;

        [Test]
        public void WhenTheTaxIsUnadjustedThenTheCorrectGiftAidIsReturned()
        {
            var builder = new TaxRate.Builder();
            builder.WithRate(FirstTaxationRate)
                   .Build()
                   .Persist();

            var calculator = CalculatorFactory.Create();
            var giftAidCalculation = calculator.Execute(100, EventType.Default);

            Assert.That(giftAidCalculation, Is.EqualTo(25m));
        }

        [Test]
        public void WhenTheTaxIsAdjustedThenTheCorrectGiftAidIsReturned()
        {
            var builder = new TaxRate.Builder();
            builder.WithRate(SecondTaxationRate)
                   .Build()
                   .Persist();

            var calculator = CalculatorFactory.Create();
            var giftAidCalculation = calculator.Execute(100, EventType.Default);

            Assert.That(giftAidCalculation, Is.EqualTo(1.52m));
        }

    }
}
