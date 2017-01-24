namespace GiftAidCalculator
{
    using System.Configuration;
    using Interfaces;

    public class TaxRateRetriever : ITaxRateRetriever
    {
        public decimal Retrieve()
        {
            var retrieve = decimal.Parse(ConfigurationManager.AppSettings["TaxRate"]);

            return retrieve;
        }
    }
}