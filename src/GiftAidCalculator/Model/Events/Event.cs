namespace GiftAidCalculator.Model.Events
{
    public abstract class Event
    {
        public abstract decimal CalculateSuppliment(decimal donation);
    }
}