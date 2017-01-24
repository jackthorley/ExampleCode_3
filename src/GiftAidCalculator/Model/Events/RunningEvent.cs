namespace GiftAidCalculator.Model.Events
{
    internal class RunningEvent : Event
    {
        private const int SupplimentRatio = 5;

        public override decimal CalculateSuppliment(decimal donation)
        {
            return (donation / 100) * SupplimentRatio;
        }
    }
}