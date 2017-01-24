namespace GiftAidCalculator.Model.Events
{
    internal class DefaultEvent : Event
    {
        public override decimal CalculateSuppliment(decimal donation)
        {
            return 0;
        }
    }
}