namespace GiftAidCalculator.AcceptanceTests.Helpers
{
    using System.Configuration;

    internal sealed class TaxRate
    {
        public decimal Rate { get; private set; }

        public sealed class Builder
        {
            TaxRate _taxRate = new TaxRate();
            
            public Builder WithRate(decimal rate)
            {
                _taxRate.Rate = rate;
                return this;
            }

            public TaxRate Build()
            {
                var returnedTaxRate = _taxRate;
                
                _taxRate = null;
                return returnedTaxRate;
            }
        }

        public void Persist()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configFile.AppSettings.Settings["TaxRate"].Value = Rate.ToString();
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
