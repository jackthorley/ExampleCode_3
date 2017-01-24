namespace GiftAidCalculator.Model.Events
{
    internal class SwimmingEvent : Event
    {
        private const int SupplimentRatio = 3;

        public override decimal CalculateSuppliment(decimal donation)
        {
            return (donation / 100) * SupplimentRatio;
        }
    }
}