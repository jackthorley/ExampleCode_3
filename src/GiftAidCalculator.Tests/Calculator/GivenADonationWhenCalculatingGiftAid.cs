namespace GiftAidCalculator.Tests.Calculator
{
    using System;
    using Interfaces;
    using Model;
    using Model.Events;
    using Moq;
    using NUnit.Framework;
    using Calculator = GiftAidCalculator.Calculator;

    public class GivenADonationWhenCalculatingGiftAid
    {
        private Mock<ITaxRateRetriever> _taxRateRetriever;
        private Mock<IGiftAidService> _giftAidService;
        private long _donation;
        private int _taxRate;
        private int _expectedResult;
        private decimal _giftAidResult;
        private Event _expectedEvent;

        [TestFixtureSetUp]
        public void Given()
        {
            _taxRate = 12;
            _expectedResult = 4233;
            _expectedEvent = EventType.Running;

            _giftAidService = new Mock<IGiftAidService>();
            _giftAidService
                .Setup(gas => gas.CalculateGiftAid(It.IsAny<Donation>(), It.IsAny<decimal>()))
                .Returns(_expectedResult);
            
            _taxRateRetriever = new Mock<ITaxRateRetriever>();
            _taxRateRetriever.Setup(trr => trr.Retrieve())
                             .Returns(_taxRate);

            var calculator = new Calculator(_taxRateRetriever.Object, _giftAidService.Object);

            _donation = DateTime.UtcNow.Ticks;
            _giftAidResult = calculator.Execute(_donation, _expectedEvent);
        }

        [Test]
        public void ThenTheTaxRateIsLoaded()
        {
            _taxRateRetriever.Verify(trq => trq.Retrieve());
        }

        [Test]
        public void ThenTheGiftAidIsCalculated()
        {

            _giftAidService.Verify(gas => gas.CalculateGiftAid(It.Is<Donation>(d => d.DonationAmount == _donation), _taxRate));
        }

        [Test]
        public void ThenTheCorrectGiftAidIsReturned()
        {
            Assert.That(_giftAidResult, Is.EqualTo(_expectedResult));
        }
    }
}