namespace GiftAidCalculator
{
    using System;
    using Interfaces;
    using Model;

    //Tested by virtue of the acceptance tests currently. Unit tests could drive this implementation then be removed after.
    internal class GiftAidService : IGiftAidService
    {
        public decimal CalculateGiftAid(Donation donation, decimal taxRate)
        {
            var giftAidRatio = (taxRate / (100 - taxRate));
            var giftAid = donation.DonationAmount * giftAidRatio;
            giftAid += donation.Event.CalculateSuppliment(donation.DonationAmount);

            return Math.Round(giftAid, 2);
        }
    }
}