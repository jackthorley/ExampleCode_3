namespace GiftAidCalculator.AcceptanceTests
{
    using Helpers;
    using NUnit.Framework;

    [SetUpFixture]
    public class TestSetupAndTeardown
    {
        private TaxRate.Builder _taxRateBuilder;

        [SetUp]
        public void SetupEnvironment()
        {
            _taxRateBuilder = new TaxRate.Builder();
            _taxRateBuilder.WithRate(20)
                          .Build()
                          .Persist();
        }

        [TearDown]
        public void Cleanup()
        {
        }
    }
}
