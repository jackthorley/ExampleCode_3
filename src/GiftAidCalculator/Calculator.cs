namespace GiftAidCalculator
{
    using Interfaces;
    using Model;
    using Model.Events;

    internal class Calculator : ICalculator
    {
        private readonly ITaxRateRetriever _taxRateRetriever;
        private readonly IGiftAidService _giftAidService;

        public Calculator(ITaxRateRetriever taxRateRetriever, IGiftAidService giftAidService)
        {
            _taxRateRetriever = taxRateRetriever;
            _giftAidService = giftAidService;
        }

        public decimal Execute(decimal donation, Event @event)
        {
            var donationBuilder = new Donation.Builder();
            var donationInternal = donationBuilder.WithDonation(donation)
                                                  .WithEvent(@event)
                                                  .Build();

            var taxRate = _taxRateRetriever.Retrieve();
            return _giftAidService.CalculateGiftAid(donationInternal, taxRate);
        }
    }
}