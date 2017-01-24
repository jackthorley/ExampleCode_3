namespace GiftAidCalculator.Interfaces
{
    using Model;

    internal interface IGiftAidService
    {
        decimal CalculateGiftAid(Donation donation, decimal taxRate);
    }
}