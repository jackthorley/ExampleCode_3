namespace GiftAidCalculator.AcceptanceTests
{
    using System;
    using System.IO;
    using Model.Events;
    using NUnit.Framework;
    using TestConsole;

    [TestFixture]
    public class GivenADonorEligibleForGiftAidWhenGivingADonation
    {
        private decimal _totalDonation;

        [TestFixtureSetUp]
        public void Given()
        {
            var donation = 1213.1234m;

            var giftAidCalculatorEngine = CalculatorFactory.Create();

            _totalDonation = giftAidCalculatorEngine.Execute(donation, new DefaultEvent());
        }

        [Test]
        public void ThenTheGiftAidValueIsReturned()
        {
            Assert.That(_totalDonation, Is.EqualTo(303.28m));
        }
    }

    /*
     * I don't really 100% agree with this test, but traditionally an Acceptance test should test the user's
     * experience with the system. As the 'TestConsole' is named as such I assume it's just a test rig to put
     * some numbers in.
     */
    [TestFixture(Ignore = true, IgnoreReason = "Deprecated with new UI elements")]
    public class GivenADonorEligibleForGiftAidWhenGivingADonationUiTest
    {
        private StringWriter _output;
        private StringReader _input;

        [TestFixtureSetUp]
        public void Given()
        {
            var donation = 123456.12m;

            _output = new StringWriter();
            _input = new StringReader(donation.ToString());

            Console.SetOut(_output);
            Console.SetIn(_input);

            Program.Main();
        }

        [Test]
        public void ThenTheGiftAidValueIsReturned()
        {
            var totalInterfaceOutput = _output.ToString();
            Assert.That(totalInterfaceOutput, Is.StringContaining("30864.03"));
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _output.Dispose();
            _input.Dispose();
        }
    }
}
