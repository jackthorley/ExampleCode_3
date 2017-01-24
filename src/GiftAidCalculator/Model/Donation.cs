namespace GiftAidCalculator.Model
{
    using Events;

    internal sealed class Donation
    {
        public decimal DonationAmount { get; private set; }
        public Event Event { get; private set; }

        public sealed class Builder
        {
            private Donation _donation = new Donation();
            private Event _event = new DefaultEvent();

            public Builder WithDonation(decimal donation)
            {
                _donation.DonationAmount = donation;
                return this;
            }

            public Builder WithEvent(Event eventType)
            {
                _event = eventType;
                return this;
            }

            public Donation Build()
            {
                _donation.Event = _event;

                var returnedDonation = _donation;
                
                _donation = null;
                return returnedDonation;
            }
        }
    }
}