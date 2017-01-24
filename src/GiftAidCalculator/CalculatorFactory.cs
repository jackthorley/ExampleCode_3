namespace GiftAidCalculator
{
    using Interfaces;

    public class CalculatorFactory
    {
        public static ICalculator Create()
        {
            return new Calculator(new TaxRateRetriever(), new GiftAidService());
        }

    }
}
